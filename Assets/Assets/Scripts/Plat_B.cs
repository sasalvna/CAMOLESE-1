using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_B : MonoBehaviour
{
    public int speed;
    public Transform Pos_C, Pos_D;
    Vector2 pos_Plat;

    void Start()
    {
        pos_Plat = Pos_C.position;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, Pos_C.position) < 0.1f)
        {
            pos_Plat = Pos_D.position;
        }
        if(Vector2.Distance(transform.position, Pos_D.position) < 0.1f)
        {
            pos_Plat = Pos_C.position;
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