using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;

    [SerializeField] private int speed;
    [SerializeField] private int forcaPulo;
    [SerializeField] private Animator animator;
    private bool PodePular, PuloDuplo;
    private int Vida;

    [SerializeField] SpriteRenderer SR;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Vida = 3;
        transform.position = new Vector2(0f, -1.41f);
        PodePular = false;
        PuloDuplo = false;
    }

    void Update()
    {
        Mover();
        Pular();
        Morte();

    }

    void Mover()
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

    void Pular()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (PodePular = true)
            {
                rig.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
                PodePular = false;
                PuloDuplo = true;
                animator.SetBool("jump", true);
            }

        }
            else if( PodePular == false && PuloDuplo)
            {
                rig.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
                PodePular = false;
                PuloDuplo = false;
                animator.SetBool("jump", false);
            }
        }

    void Morte()
    {
        if(Vida == 0)
        {
            Destroy(this.gameObject);
             SceneManager.LoadScene("Morte");
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Plataforma"))
        {
            PodePular = true;
        }

        if (colisao.gameObject.CompareTag("Chao"))
        {
            PodePular = false;
        }

        if(colisao.gameObject.CompareTag("Mola"))
        {
            PodePular = false;
        }

        if (colisao.gameObject.CompareTag("Espinho"))
        {
            Vida = Vida - 1;
        }

        if (colisao.gameObject.CompareTag("V2"))
        {
           Vida = 0;
        }
    }
    //void OnCollisionExit2D(Collision colisao)
   // {

   // }
}