using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;

    Animator animator;

    SpriteRenderer SR;

    BoxCollider2D box;

    private int Vida;

    [SerializeField] private int speed;

    [SerializeField] private int JumpForce;

    [SerializeField] private bool isJumping, doubleJump;

    void Start()
    {
        animator = GetComponent<Animator>();

        rig = GetComponent<Rigidbody2D>();

        box = GetComponent<BoxCollider2D>();

        Vida = 3;

        SR = GetComponent<SpriteRenderer>();

        transform.position = new Vector2(0f, -1.41f);

        isJumping = false;

        doubleJump= false;
    }

    void Update()
    {
        Move();
        Jump();
        Die();
    }

    void Move()
    {
        rig.velocity= new Vector2(Input.GetAxis("Horizontal") * speed, rig.velocity.y);

        if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("idle", true);
            animator.SetBool("run", false);
        }
        else
        {
            animator.SetBool("idle", false);
        }

        
        if(Input.GetAxis("Horizontal") > 0)
        {
            SR.flipX = false;
            animator.SetBool("run", true);
        }

        if(Input.GetAxis("Horizontal") < 0)
        {
            SR.flipX = true;
            animator.SetBool("run", true);
        }

        if(rig.velocity.y < 0)
        {
            animator.SetBool("fall", true);
        }
        else
        {
             animator.SetBool("fall", false);
        }

        if(rig.velocity.y > 0)
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                rig.AddForce( new Vector2(0f, JumpForce) , ForceMode2D.Impulse);
                doubleJump = true;
                animator.SetBool("jump", true);
            } 
            else
            {
                if(doubleJump)
                {
                    rig.AddForce( new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    animator.SetBool("jump", false);
                    animator.SetBool("dobleJump", true);
                    doubleJump = false;
                }
            }
        }
    }

    void Die()
    {
        if(Vida == 0)
        {
            SceneManager.LoadScene("Morte");
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Espinho"))
        {
            Vida = Vida - 1;
        }

        if (colisao.gameObject.CompareTag("V2"))
        {
           Vida = 0;
        }

        // Layer 8 = Ground

        if (colisao.gameObject.layer == 8)
        {
            isJumping = false;
            animator.SetBool("idle", true);
            animator.SetBool("dobleJump", false);
            animator.SetBool("jump", false);

        }
    }
    void OnCollisionExit2D(Collision2D colisao)
   {
        if (colisao.gameObject.layer == 8)
        {
           isJumping = true;
        }
   }
}