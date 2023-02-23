using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Option_Manager : MonoBehaviour
{
    public GameObject option;
    public GameObject Gallery;
    public GameObject Exit;
    public GameObject Exit_Window;
    GameObject Player;

    public static Option_Manager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "a03_SoloPlay" && option.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player_home");
        }

        if(option.activeSelf == true)
        {
            if(SceneManager.GetActiveScene().name == "a01_Title")
            {
                Gallery.SetActive(true);
            }
            else if(SceneManager.GetActiveScene().name == "a03_SoloPlay")
            {
                Exit.SetActive(true);
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "a03_SoloPlay")
            {
                if(option.activeSelf == false)
                {
                    option.SetActive(true);
                    Exit.SetActive(true);
                }
                else if (Exit_Window.activeSelf == false)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    option.SetActive(false);
                    Exit.SetActive(false);
                }
                else if(Exit_Window.activeSelf == true)
                {
                    Exit_Window.SetActive(false);
                }
            }
        }

        SceneManager.sceneLoaded += OnSceneLoded;
    }

    void OnSceneLoded(Scene scene, LoadSceneMode mode)
    {
        Cursor.visible = false;
        option.SetActive(false);
        Exit.SetActive(false);
        Gallery.SetActive(false);
    }

    public void C_x_bt()
    {
        if (SceneManager.GetActiveScene().name == "a01_Title")
        {
            option.SetActive(false);
            Gallery.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "a03_SoloPlay")
        {
            option.SetActive(false);
            Exit.SetActive(false);
            Exit_Window.SetActive(false);
        }

    }
    public void C_g_bt()
    {
        
        option.SetActive(false);
        Gallery.SetActive(false);
        SceneManager.LoadScene("a06_Gallery2");
    }
    public void C_e_bt()
    {
        Exit_Window.SetActive(true);
    }
    public void Exit_Yes()
    {
        if(Player != null)
            Destroy(Player);
        GameManager.Instance.CharacterInt.bCountCharacter = true;
        SceneManager.LoadScene("a02_SoloLobby");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        option.SetActive(false);
        Exit.SetActive(false);
        Exit_Window.SetActive(false);

        FindObjectOfType<SoundManager>().StopAudio("SE");
        FindObjectOfType<SoundManager>().PlayAudio("Title", "BGM");
        
    }
    public void Exit_No()
    {
        Exit_Window.SetActive(false);
    }

    public void OnClick()
    {
        FindObjectOfType<SoundManager>().PlayAudio("Click", "SE");
    }
}
