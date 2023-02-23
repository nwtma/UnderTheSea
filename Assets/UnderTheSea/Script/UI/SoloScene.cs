using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoloScene : MonoBehaviour
{
    public GameObject Ch_01;
    public GameObject Ch_02;
    public GameObject Ch_03;
    public GameObject Ch_04;

    public int ChargeCA;

    public CharactersSelection Ch_Selection;
    public Animation anime;

    void Start()
    {
        Ch_Selection = this.gameObject.GetComponent<CharactersSelection>();
    }
    public void StartButton()
    {
        if (Ch_Selection.Ch_1.activeSelf == false && Ch_Selection.Ch_2.activeSelf == false&& Ch_Selection.Ch_3.activeSelf == false&& Ch_Selection.Ch_4.activeSelf == false)
        {
            anime.Play();

            return;
        }
        else if (Ch_Selection.Ch_1.activeSelf == true)
        {
            Ch_01.SetActive(true);
            
        }
        else if (Ch_Selection.Ch_2.activeSelf == true)
        {
            Ch_02.SetActive(true);
        }
        else if (Ch_Selection.Ch_3.activeSelf == true)
        {
            Ch_03.SetActive(true);
        }
        else if (Ch_Selection.Ch_4.activeSelf == true)
        {
            Ch_04.SetActive(true);
            
        }
        GameManager.Instance.CharacterInt.bCountCharacter = false;
        SceneManager.LoadScene("a03_SoloPlay");
        
    }

    public void OnClick()
    {
        FindObjectOfType<SoundManager>().PlayAudio("Click", "SE");
    }
}