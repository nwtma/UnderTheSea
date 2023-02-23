using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersSelection : MonoBehaviour
{
    public GameObject Ch_1;
    public GameObject Ch_2;
    public GameObject Ch_3;
    public GameObject Ch_4;

    public GameObject Player_home;

    public int random;
    void Start()
    {
        DontDestroyOnLoad(Player_home);
        Ch_1.SetActive(false);
        Ch_2.SetActive(false);
        Ch_3.SetActive(false);
        Ch_4.SetActive(false);
        GameManager.Instance.CharacterInt.bCountCharacter = true;
    }
    public void ClickCh_1()
    {
        Ch_1.SetActive(true);
        Ch_2.SetActive(false);
        Ch_3.SetActive(false);
        Ch_4.SetActive(false);

        GameManager.Instance.CharacterInt.bCharacterindia = true;
        GameManager.Instance.CharacterInt.bCharacterwhite = false;
        GameManager.Instance.CharacterInt.bCharacterfish = false;
        GameManager.Instance.CharacterInt.bCharactershark = false;

    }
    public void ClickCh_2()
    {
        Ch_2.SetActive(true);
        Ch_1.SetActive(false);
        Ch_3.SetActive(false);
        Ch_4.SetActive(false);

        GameManager.Instance.CharacterInt.bCharacterindia = false;
        GameManager.Instance.CharacterInt.bCharacterwhite = true;
        GameManager.Instance.CharacterInt.bCharacterfish = false;
        GameManager.Instance.CharacterInt.bCharactershark = false;
    }
    public void ClickCh_3()
    {
        Ch_3.SetActive(true);
        Ch_1.SetActive(false);
        Ch_2.SetActive(false);
        Ch_4.SetActive(false);

        GameManager.Instance.CharacterInt.bCharacterindia = false;
        GameManager.Instance.CharacterInt.bCharacterwhite = false;
        GameManager.Instance.CharacterInt.bCharacterfish = true;
        GameManager.Instance.CharacterInt.bCharactershark = false;
    }
    public void ClickCh_4()
    {
        Ch_4.SetActive(true);
        Ch_1.SetActive(false);
        Ch_2.SetActive(false);
        Ch_3.SetActive(false);

        GameManager.Instance.CharacterInt.bCharacterindia = false;
        GameManager.Instance.CharacterInt.bCharacterwhite = false;
        GameManager.Instance.CharacterInt.bCharacterfish = false;
        GameManager.Instance.CharacterInt.bCharactershark = true;
    }
}
