using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] Button QuitButton;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(StartGame);
        QuitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        GameManager.Instance.GameStart();
        SceneManager.LoadScene("MainScene");
        
    }

   
}
