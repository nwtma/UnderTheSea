using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gallery : MonoBehaviour
{
    public GameObject G1;
    public GameObject G2;
    public GameObject G3;
    public GameObject G4;
    public GameObject G5;
    public GameObject G6;

    public GameObject A1;
    public GameObject A2;

    public int check = 1;

    public void ClickSound()
    {
        FindObjectOfType<SoundManager>().PlayAudio("click", "SE");
    }
    
    public void ClickRightArrow()
    {
        switch(check)
        {
            case 1:
                {
                    G2.SetActive(true);
                    A2.SetActive(true);
                    check = 2;
                    G1.SetActive(false);
                }
                break;

            case 2:
                {
                    G3.SetActive(true);
                    check = 3;
                    G2.SetActive(false);
                }
                break;

            case 3:
                {
                    G4.SetActive(true);
                    check = 4;
                    G3.SetActive(false);
                }
                break;

            case 4:
                {
                    G5.SetActive(true);
                    check = 5;
                    G4.SetActive(false);
                }
                break;

            case 5:
                {
                    G6.SetActive(true);
                    A1.SetActive(false);
                    check = 6;
                    G5.SetActive(false);
                }
                break;


        }
    }
    public void ClickLeftArrow()
    {
        switch(check)
        {
            case 2:
                {
                    G1.SetActive(true);
                    A2.SetActive(false);
                    check = 1;
                    G2.SetActive(false);
                }
                break;

            case 3:
                {
                    G2.SetActive(true);
                    check = 2;
                    G3.SetActive(false);
                }
                break;

            case 4:
                {
                    G3.SetActive(true);
                    check = 3;
                    G4.SetActive(false);
                }
                break;

            case 5:
                {
                    G4.SetActive(true);
                    check = 4;
                    G5.SetActive(false);
                }
                break;

            case 6:
                {
                    G5.SetActive(true);
                    A1.SetActive(true);
                    check = 5;
                    G6.SetActive(false);
                }
                break;
        }
    }
}
