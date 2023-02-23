using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffEffect : MonoBehaviour
{
    public float turnOffTime;
    private float time;

    public bool isDestroy;
    public bool isSetActive;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > turnOffTime)
        {
            if (isDestroy)
            {
                Destroy(gameObject);
            }

            else if (isSetActive)
            {
                gameObject.SetActive(false);
                time = 0;
            }
        }
    }
}
