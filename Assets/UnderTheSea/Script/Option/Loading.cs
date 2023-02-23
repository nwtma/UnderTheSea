using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public float Loading_Time;

    // Update is called once per frame
    void Update()
    {
        Loading_Time += Time.deltaTime;
        if (Loading_Time >= 2)
        {
            SceneManager.LoadScene("a01_Title");
        }
    }
}
