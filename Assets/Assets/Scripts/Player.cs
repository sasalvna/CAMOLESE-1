using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;

    [SerializeField] private int speed;
    [SerializeField] private int forcaPulo;
    private bool PodePular, PuloDuplo;
    private int Vida;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Vida = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Pular();
        Morte();
    }

    void Mover()
    {
        rig.velocity= new Vector2(Input.GetAxis("Horizontal") * speed, rig.velocity.y);
    }

    void Pular()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (PodePular)
            {
                rig.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
                PodePular = false;
                PuloDuplo = true;
            }
            else if( !PodePular && PuloDuplo)
            {
                rig.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
                PodePular = false;
                PuloDuplo = false;
            }
        }
    }

    void Morte()
    {
        if(Vida = 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Plataforma"))
        {
            PodePular = true;
        }
        else
        {
            PodePular = false;
        }
        if (colisao.gameObject.CompareTag("Chão"))
        {
            PodePular = false;
        }
        else 
        {
            PodePular = true;
        }
        if(colisao.gameObject.CompareTag("Mola"))
        {
            PodePular = false;
        }

        if (colisao.gameObject.CompareTag("Espinho"))
        {
            Vida = Vida - 1;
        }
    }
}