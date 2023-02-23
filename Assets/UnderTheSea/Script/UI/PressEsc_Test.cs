using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressEsc_Test : MonoBehaviour
{
    //public GameObject Kill_List;
    GameObject Player;
    
    private void Start()
    {
        Time.timeScale = 0;
        SoundManager.instance.PlayAudio("InGame", "BGM");
    }

    EffectManager effectManager = new EffectManager();

    private void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    Kill_List.SetActive(true);
        //}

        //else if (Input.GetKeyUp(KeyCode.Tab))
        //{
        //    Kill_List.SetActive(false);
        //}
    }
}
