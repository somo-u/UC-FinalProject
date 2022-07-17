using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Players : MonoBehaviour
{
    public float speed;
    public float jump;
    private float move;
    private bool playerJump;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;

    private int partsofrocket = 0;
   public TextMeshProUGUI collectText ;

    void Start()
    {
        //speed = 2.5f;

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //    //for left and right movement;
        Vector2 temp = rb.velocity;
        temp.x = Input.GetAxis("Horizontal") * speed;
        rb.velocity = temp;


        if (Input.GetAxis("Horizontal") > 0)
        {
            sprite.flipX = false;

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {


            sprite.flipX = true;
        }

        if (Input.GetButtonDown("Jump") && !playerJump)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            playerJump = true;
        }

        MyAnimations();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerJump = false;

        }

        if (collision.gameObject.CompareTag("rocket") && partsofrocket == 3)
        {
            SceneManager.LoadScene(2);
        } 
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);

        if (other.gameObject.CompareTag("collect"))
        {
            Destroy(other.gameObject);
            partsofrocket++;
            collectText.text = "X" + partsofrocket;

              
        }
    }


    void MyAnimations()

    {
    animator.SetFloat("movement", Mathf.Abs(move));
    animator.SetBool("playerJump", playerJump);

    }
}


//Walking = Input.GetAxis("Horizontal");
//rb.velocity = new Vector2(Walking * speed, rb.velocity.y);







//{
//    Rigidbody2D rb;
//    public float speed;
//public float jump;
//public bool blCanJump = false;
//public Animator animator;
//public SpriteRenderer sprite;
//private void OnCollisionEnter2D(Collision2D collision)
//{
//    if (collision.gameObject.tag == "Ground")
//    {
//        blCanJump = true;
//        animator.SetBool("jump", false);

//    }
//    else if (collision.gameObject.tag == "Enemy")
//    {
//        Destroy(gameObject);
//    }
//}

//private void OnTriggerEnter2D(Collider2D other)
//{
//    if (other.gameObject.tag == "Enemy")
//    {
//        Destroy(other.gameObject);
//    }
//}
//// Start is called before the first frame update
//void Start()
//{
//    speed = 10;
//    jump = 5;
//    rb = GetComponent<Rigidbody2D>();
//    animator = GetComponent<Animator>();
//    sprite = GetComponent<SpriteRenderer>();

//}

//// Update is called once per frame
//void Update()
//{
//    Vector2 temp = rb.velocity;

//    if (Input.GetAxis("Horizontal") > 0)
//    {
//        sprite.flipX = false;

//    }
//    else if (Input.GetAxis("Horizontal") < 0)
//    {


//        sprite.flipX = true;
//    }

//    //for jumping part
//    if (blCanJump)
//    {

//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            temp.y = jump;
//            blCanJump = false;
//            animator.SetBool("jump", true);

//        }
//    }

//    //for left and right movement;
//    temp.x = Input.GetAxis("Horizontal") * speed;
//    rb.velocity = temp;

//}



//}
