using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timerrrr : MonoBehaviour
{
    [SerializeField] public float Limit;
    [SerializeField] public float time;
    [SerializeField] public Text timer;

    public void Start()
    {
        time = Limit;
    }
    public void SpawnTime()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        timer.text = string.Format("{0:D2}", (int)time + 1);
    }
}
