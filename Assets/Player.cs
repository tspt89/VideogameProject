using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float velocity = 10f;
    private Rigidbody2D rbody;
    private Animator anim;
    private bool flip = false;

    public Transform feet;
    float widthFeet = 0.2f;
    float jumpForce = 600f;
    public LayerMask ground;
    bool inGround = false;
    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

        if(Input.GetKeyDown(KeyCode.Space) && inGround)
        {
            rbody.AddForce(new Vector2(0, jumpForce));
        }

    } 
    
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
