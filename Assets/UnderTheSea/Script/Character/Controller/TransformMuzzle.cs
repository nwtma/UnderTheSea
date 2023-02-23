using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMuzzle : MonoBehaviour
{
    public GameObject muzzle;

    // Start is called before the first frame update
    void Start()
    {
        muzzle = GameObject.Find("Muzzle");
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = muzzle.transform.position;
    }
}
