using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public GameObject Exit_Window;
    private GameObject Player;
    public GameObject option;
    public GameObject Gallery_;
    
    public void OnClick()
    {
        FindObjectOfType<SoundManager>().PlayAudio("Click", "SE");
    }


    public void SoloPlay()
    {
        SceneManager.LoadScene("a02_SoloLobby");
    }
    public void MultiPlay()
    {
        SceneManager.LoadScene("a02_MultiLobby");
    }
    public void Gallery()
    {
        SceneManager.LoadScene("a04_Gallery");
    }
    public void Credit()
    {
        SceneManager.LoadScene("a05_Credit");
    }
    public void Exit()
    {
        Exit_Window.SetActive(true);
    }
    public void Exit_Yes()
    {
        Debug.Log("종료");
        Application.Quit();
    }
    public void Exit_No()
    {
        Exit_Window.SetActive(false);
    }
    //public void mt()
    //{
    //    SceneManager.LoadScene("lobby");
    //}


    public void Option()
    {
        option.SetActive(true);
    }

    public void Close_option()
    {
        option.SetActive(false);
    }

    void Awake()
    {
        Player = GameObject.FindWithTag("Player_home");
        Destroy(Player);
        option = GameObject.Find("Window").transform.Find("Option_Window").gameObject;
        Gallery_ = GameObject.Find("Window").transform.Find("Gallery").gameObject;
        //FindObjectOfType<SoundManager>().PlayAudio("Title", "BGM");
    }

private void Update()
    {
        GameManager.Instance.CharacterInt.bCountCharacter = false;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Exit_Window.activeSelf == true)
            {
                Exit_Window.SetActive(false);
            }
            else if (Exit_Window.activeSelf == false && option.activeSelf == false)
            {
                Exit_Window.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else if(option.activeSelf == true)
            {
                option.SetActive(false);
                Gallery_.SetActive(false);
            }
        }
    }
}
