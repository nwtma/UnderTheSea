using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterInt : MonoBehaviour
{

    private GameObject CAT_1;
    private GameObject CAT_2;
    private GameObject CAT_3;
    private GameObject CAT_4;

    public int CharacterShark = 0;
    public int CharacterIndia = 0;
    public int CharacterWhite = 0;
    public int CharacterFish = 0;
    public int CharacterCA = 0;

    public bool bCharactershark = false;
    public bool bCharacterindia = false;
    public bool bCharacterwhite = false;
    public bool bCharacterfish = false;
    public bool bCountCharacter = false;

    public int ChargeCA;

    public void Update()
    {
        CharacterSelect();

        ChargeSelect();
    }

    void CharacterSelect()
    {
        if (bCountCharacter)
        {
            if (bCharacterindia)
            {
                CharacterIndia = 1;
                CharacterShark = 0;
                CharacterWhite = 0;
                CharacterFish = 0;
                bCharactershark = false;
                bCharacterwhite = false;
                bCharacterfish = false;
                ChargeCA = 0;
                CharacterCA = 1;
            }
            if (bCharacterwhite)
            {
                CharacterWhite = 1;
                CharacterFish = 0;
                CharacterShark = 0;
                CharacterIndia = 0;

                bCharactershark = false;
                bCharacterindia = false;
                bCharacterfish = false;
                ChargeCA = 0;
                CharacterCA = 1;
            }
            if (bCharacterfish)
            {
                CharacterFish = 1;
                CharacterShark = 0;
                CharacterIndia = 0;
                CharacterWhite = 0;

                bCharactershark = false;
                bCharacterindia = false;
                bCharacterwhite = false;
                ChargeCA = 0;
                CharacterCA = 1;
            }
            if (bCharactershark)
            {
                CharacterShark = 1;
                CharacterIndia = 0;
                CharacterWhite = 0;
                CharacterFish = 0;
                bCharacterindia = false;
                bCharacterwhite = false;
                bCharacterfish = false;
                ChargeCA = 0;
                CharacterCA = 1;
            }

        }
        
    }
    void ChargeSelect()
    {
        if (bCountCharacter)
        {
            if (CharacterCA == 0)
            {
                CharacterShark = 0;
                CharacterIndia = 0;
                CharacterWhite = 0;
                CharacterFish = 0;
                bCharactershark = false;
                bCharacterindia = false;
                bCharacterwhite = false;
                bCharacterfish = false;
                CharacterCA = 0;
            }
        }
    }
}