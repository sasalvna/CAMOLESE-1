using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_C : MonoBehaviour
{
    public int speed;
    public Transform Pos_E, Pos_F;
    Vector2 pos_Plat;

    void Start()
    {
        pos_Plat = Pos_E.position;
        speed = 5;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, Pos_E.position) < 0.1f)
        {
            pos_Plat = Pos_F.position;
        }
        if(Vector2.Distance(transform.position, Pos_F.position) < 0.1f)
        {
            pos_Plat = Pos_E.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, pos_Plat, speed * Time.deltaTime);
    }

        void OnCollisionEnter2D (Collision2D colisao)
        {
            if (colisao.gameObject.CompareTag("Player"))
            {
                colisao.transform.SetParent(this.transform);
            }
        }

        void OnCollisionExit2D (Collision2D colisao)
        {
            if (colisao.gameObject.CompareTag("Player"))
            {
                colisao.transform.SetParent(null);
            }
        }   
}