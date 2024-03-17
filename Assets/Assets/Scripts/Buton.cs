using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buton : MonoBehaviour
{
    
    [SerializeField] private Button BotaoRenascer;

    GameObject MenuGameUI;

    private void Awake()
    {
        BotaoRenascer.onClick.AddListener(OnButtonPlayClickRenascer);
    }

    private void OnButtonPlayClickRenascer()
    {
        Debug.Log("RENASCER");
        
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}