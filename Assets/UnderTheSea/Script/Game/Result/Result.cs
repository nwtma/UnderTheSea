using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public GameObject vic;
    public GameObject vicbg;
    public GameObject lose;
    public GameObject losebg;

    void Start()
    {
        if(GameManager.Instance.result == true)
        {
            vic.SetActive(true);
            vicbg.SetActive(true);
            FindObjectOfType<SoundManager>().PlayAudio("victory", "SE");
        }

        else if(GameManager.Instance.result == false)
        {
            lose.SetActive(true);
            losebg.SetActive(true);
            FindObjectOfType<SoundManager>().PlayAudio("defeat", "SE");
        }
    }
    
}
