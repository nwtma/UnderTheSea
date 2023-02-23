using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSpeed : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Time.timeScale = 3.0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Time.timeScale = 1.0f;
        }
    }
}
