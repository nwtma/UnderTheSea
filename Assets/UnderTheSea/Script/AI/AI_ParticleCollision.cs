using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_ParticleCollision : MonoBehaviour
{
    [SerializeField] float fDamage;

    public void OnParticleCollision(GameObject other)
    {
        if(other.tag != "Player")
        {
            return;
        }

        Health health = other.transform.GetComponentInChildren<Health>();
        var Bullet_ = other.transform.parent;

        if (Bullet_ != null && Bullet_.tag == "Bullet")
        {
            return;
        }

        if (health != null)
        {
            health.TakenDamage(fDamage, gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
