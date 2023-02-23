using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameGoal : MonoBehaviour
{
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Time.timeScale = 1;
            this.gameObject.SetActive(false);
        }
    }
}
