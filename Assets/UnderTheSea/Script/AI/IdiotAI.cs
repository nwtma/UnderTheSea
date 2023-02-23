using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class IdiotAI : MonoBehaviour
{
    NavMeshAgent age;
    [SerializeField] public Ai_Weapon weapon;

    private void Awake()
    {
        age = this.GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Indiaink(Clone)")
        {
            StartCoroutine(StopAI());
        }
    }

    IEnumerator StopAI()
    {
        age.enabled = false;

        float rateFire = weapon.fRateOfFire;
        //weapon.fRateOfFire = 4;
        weapon.enabled = false;

        yield return new WaitForSeconds(3f);

        age.enabled = true;
        //weapon.fRateOfFire = rateFire;
        weapon.enabled = true;
        yield break;
    }
}
