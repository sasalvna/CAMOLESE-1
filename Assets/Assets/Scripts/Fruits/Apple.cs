using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer SR;

    public CircleCollider2D circle;

    public GameObject collected;

    public int Score;
    
    void Start()
    {   
        SR = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SR.enabled = false;

            circle.enabled = false;

            collected.SetActive(true);

            Debug.Log("Coletou Fruta");

            Destroy(this.gameObject, 0.3f);

            GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText();

        }
    }
}