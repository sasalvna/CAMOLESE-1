using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar_Plataforma : MonoBehaviour
{
    public int speed;
    public Transform L1, L2;
    Vector2 pos_Plat;

    void Start()
    {
        pos_Plat = L1.position;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, L1.position) < 0.1f)
        {
            pos_Plat = L2.position;
        }
        if(Vector2.Distance(transform.position, L2.position) < 0.1f)
        {
            pos_Plat = L1.position;
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