using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform bulletperfab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter (Collider bullet)
    {
        bullet = bulletperfab.GetComponent<Collider>();

        Physics.IgnoreCollision(bulletperfab.GetComponent<Collider>(), bullet.GetComponent<Collider>());
    }
}
