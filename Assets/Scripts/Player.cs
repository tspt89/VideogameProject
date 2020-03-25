using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public AudioSource effects;
    public AudioClip jump;
    public AudioClip hurt;
    public AudioClip death;
    public AudioClip victory;

    float velocity = 5f;
    private Rigidbody2D rbody;
    private Animator anim;

    public int Energy = 5;
    public bool isAlive = true;

    public Transform feet;
    float widthFeet = 0.2f;
    public float jumpForce = 12f;
    public LayerMask ground;
    bool inGround = false;
    bool facingRight = true;

    private CameraController camctrl;
    private gameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        camctrl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        gm = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<gameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        float walk = Input.GetAxis("Horizontal"); //Horizontal axis of the player
        rbody.velocity = new Vector2(walk * velocity, rbody.velocity.y); //velocity of the player
        anim.SetFloat("Speed", Mathf.Abs(walk)); //We send it to unity parameter 
        anim.SetFloat("altura", rbody.velocity.y);
        inGround = Physics2D.OverlapCircle(feet.position, widthFeet, ground);
        anim.SetBool("Grounded", inGround);


        if (facingRight && walk < 0)
            Flip();
        else if (!facingRight && walk > 0)
            Flip();


        if (Input.GetKeyDown(KeyCode.UpArrow) && inGround)
        {
            rbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            effects.clip = jump;
            effects.Play();
        }


        if (Energy <= 0 && isAlive && inGround)
        {
            Energy = 0;
            isAlive = false;
            anim.Play("Player_death");
            effects.clip = death;
            effects.Play();
            rbody.constraints = RigidbodyConstraints2D.FreezePosition;
            camctrl.speed = 0;
            StartCoroutine(ChangeScene());

        } else if (Energy <= 0 && isAlive && !inGround)
        {
            camctrl.speed = 0;
            Wait();
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            gm.points += 1;
            effects.clip = victory;
            effects.Play();
            anim.Play("Player_celebrate");
            StartCoroutine(ChangeVictoryScene());
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }

    IEnumerator ChangeVictoryScene()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(0);
    }

    IEnumerator Wait()
    {
        Energy = 0;
        isAlive = false;
        yield return new WaitForSeconds(3);
        anim.Play("Player_death");
        effects.clip = death;
        effects.Play();
        rbody.constraints = RigidbodyConstraints2D.FreezePosition;
        
        StartCoroutine(ChangeScene());

    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
