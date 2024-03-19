using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mola : MonoBehaviour
{
    [SerializeField]
    float Impulso;


    void OnCollisionEnter2D(Collision2D colisao)
    {
        if(colisao.gameObject.CompareTag("Player"))
        {
            colisao.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Impulso, ForceMode2D.Impulse);
        }
    }
}
