using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anemone : MonoBehaviour
{
    Weapon shooter;
    [SerializeField] public bool isEnter;

    void Awake()
    {
        shooter = FindObjectOfType<Weapon>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.parent.name == "fish")
        {
            shooter.Ane_Enter = true;
            isEnter = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.name == "fish")
        {
            shooter.Ane_Enter = false;
            isEnter = false;
        }
    }
}
