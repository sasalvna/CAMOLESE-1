using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit_Game : MonoBehaviour
{

    [SerializeField] private Button ButtonQuit;

    GameObject MenuGameUI;
    private void Awake()
    {
        ButtonQuit.onClick.AddListener(OnButtonPlayClickJogar);
    }
    private void OnButtonPlayClickJogar()
    {
        Debug.Log("SAIR");
        
    }

    public void QuitGame()
    {
    
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}