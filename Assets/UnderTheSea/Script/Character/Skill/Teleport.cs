using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Anemone[] ane;
    GameObject clown;
    public GameObject TP_Effect;    //텔레포트할 때 나타날 이펙트

    void Start()
    {
        clown = GameObject.Find("fish");
    }

    public Anemone GetEnteredObject()
    {
        for(int i = 0; i < ane.Length(); ++i)
        {
            if (ane[i].isEnter)
                return ane[i];
        }
    }

    public Transform GetRandomTransform()
    {
        Transform Result;
        var EnteredObject = GetEnteredObject();
        while(true)
        {
            var RandomObject = ane[Random.Range(0, ane.Length)];
            if(EnteredObject.name != RandomObject.name)
            {
                return RandomObject.transform.position;
            }
        }
    }

    public void MoveToRandomPlace()
    {
        Transform NewPoint = GetRandomTransform();
        clown.transform.position = NewPoint.position;
        Instantiate(TP_Effect, NewPoint.position, Quaternion.identity);
    }
}
