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
    [SerializeField] GameObject PressText;
    [SerializeField]float time;
    bool CanPressbutton;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PressText.SetActive(false);
        //ToTitleButton.onClick.AddListener(OnClickedToTitleButton);
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

        StartCoroutine(wait());
    }

    private void OnClickedToTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

    private void Update()
    {
        
        if (Input.anyKey&&CanPressbutton)
        {
            CanPressbutton = false;
            OnClickedToTitleButton();
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(time);
        CanPressbutton = true;
        PressText.SetActive(true);
    }




}
