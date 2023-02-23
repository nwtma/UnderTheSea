using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LobbyToMain : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<SoundManager>().PlayAudio("Title", "BGM");
            SceneManager.LoadScene("a01_Title");
            

        }
        
    }
}
