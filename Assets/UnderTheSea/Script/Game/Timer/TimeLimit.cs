using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    public float Limit;
    public Text Timer;
    public int min;
    

    EffectManager effectManager = new EffectManager();

    // Update is called once per frame
    void Update()
    {
        if (Limit > 0)
        {
            Limit -= Time.deltaTime;
        }

        if (Limit >= 60)
        {
            min++;
            Limit -= 60;
        }

        Timer.text = string.Format("{0:D2} : {1:D2}", min, (int)Limit);

        if (Limit <= 0 && min > 0)
        {
            min--;
            Limit += 60;
        }

        if (Limit <= 0 && min == 0)
        {
            TimeOver();
            //StartCoroutine(Sleep());
        }
        else
        {
            //Time.timeScale = 1;
        }
    }

    public void TimeOver()
    {
        ResultManager.instance.Defeat();
    }
    

}