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

    float velocity = 10f;
    private Rigidbody2D rbody;
    private Animator anim;

    public int Energy = 5;
    public bool isAlive = true;

    public Transform feet;
    float widthFeet = 0.2f;
    float jumpForce = 400f;
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


        if (Input.GetKeyDown(KeyCode.Space) && inGround)
        {
            rbody.AddForce(new Vector2(0, jumpForce));
            effects.clip = jump;
            effects.Play();
        }


        if (Energy <= 0 && isAlive)
        {
            Energy = 0;
            isAlive = false;
            anim.Play("Player_death");
            effects.clip = death;
            effects.Play();
            rbody.constraints = RigidbodyConstraints2D.FreezePosition;
            camctrl.speed = 0;
            StartCoroutine(ChangeScene());

        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Coin"))
        {
            Destroy(col.gameObject);
            gm.points += 1;
            anim.Play("Player_celebrate");
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
