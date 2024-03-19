using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int totalScore;

    public static GameController instance;
    
    void Start()
    {
        instance = this;
    }
}
