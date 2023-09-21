using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverManager : MonoBehaviour
{
    [SerializeField] Button ToTitleButton;
    [SerializeField] GameObject clearText;
    [SerializeField] GameObject GameoverText;
    // Start is called before the first frame update
    void Start()
    {
        ToTitleButton.onClick.AddListener(OnClickedToTitleButton);
        if (GameManager.Instance.clear)
        {
            clearText.SetActive(true);
            GameoverText.SetActive(false);
        }
        else
        {
            GameoverText.SetActive(true);
            clearText.SetActive(false);
        }
    }

    private void OnClickedToTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
