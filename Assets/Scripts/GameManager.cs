using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;
    AudioSource m_AudioSource;
    [SerializeField]AudioClip[] audioClips;
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

   

    public void GameOver(bool Clear)
    {
        SceneManager.LoadScene("GameOverScene");
        clear = Clear;
        m_AudioSource.Stop();
     
    }

    public void GameStart()
    {
        clear = false;
        player.HP= player.MaxHP;
        Cursor.visible = false;
        m_AudioSource.clip = audioClips[0];
        m_AudioSource.Play();
    }
}
