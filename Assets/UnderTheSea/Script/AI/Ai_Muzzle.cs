using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Muzzle : MonoBehaviour
{
    public GameObject Muzzle_gora;

    void Start()
    {
        Muzzle_gora = GameObject.Find("Muzzle_gora");
    }

    void Update()
    {
        this.gameObject.transform.position = Muzzle_gora.transform.position;
    }
}
