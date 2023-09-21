using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;
    AudioSource m_AudioSource;
    public bool clear;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(bool Clear)
    {
        SceneManager.LoadScene("GameOverScene");
        clear = Clear;
     
    }
}
