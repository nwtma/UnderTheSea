using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Collections;

public class EffectManager : MonoBehaviour
{
    private GameObject effectObj;
    private UTS_Config.EffectEvent EventNum;
    private float time;

    public void GetEffectObj(GameObject obj, UTS_Config.EffectEvent eventNum)
    {
        effectObj = obj;
        EventNum = eventNum;
    }

    public void OnEffect()
    {
        effectObj.SetActive(true);
    }

    public void OffEffect()
    {
        effectObj.SetActive(false);
    }

    public void ResetTime()
    {
        time = 0f;
    }

    private void Update()
    {
        time += Time.deltaTime;
        switch (EventNum)
        {
            case UTS_Config.EffectEvent.teleport:
                {
                    if (time > UTS_Config.teleportTime)
                    {
                        OffEffect();
                        ResetTime();
                    }
                }
                break;
        }
    }
}