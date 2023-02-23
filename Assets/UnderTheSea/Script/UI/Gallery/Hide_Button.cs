using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide_Button : MonoBehaviour
{
    public GameObject con_img;  //컨셉 이미지
    public GameObject three_img;//삼면도 이미지
    public GameObject ori_img;   //원화 이미지

    public void ConceptButton()
    {
        three_img.SetActive(false);
        ori_img.SetActive(false);
        con_img.SetActive(true);
    }

    public void ThreeButton()
    {
        con_img.SetActive(false);
        ori_img.SetActive(false);
        three_img.SetActive(true);
    }

    public void OriButton()
    {
        con_img.SetActive(false);
        three_img.SetActive(false);
        ori_img.SetActive(true);
    }
}
