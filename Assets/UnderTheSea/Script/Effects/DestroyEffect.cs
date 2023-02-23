using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, gameObject.GetComponent<ParticleSystem>().duration + 1f);
    }
}
