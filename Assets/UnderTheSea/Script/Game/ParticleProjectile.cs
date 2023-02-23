using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class ParticleProjectile : MonoBehaviour
{
    private float fSpeed;
    private float fTimeToLive;
    [SerializeField]private float fDamage;

    void Start()
    {
        Destroy(gameObject, fTimeToLive);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * fSpeed);
    }

    private void OnParticleCollision(GameObject other)
    {
        Health health = other.GetComponent<Health>();
        var Bullet_ = other.transform.parent;

        if (Bullet_ != null && Bullet_.tag == "Bullet")
        {
            return;
        }

        if (health != null)
        {
            Debug.Log("잘되는거 맞제?");
            Debug.Log("맞은 놈 : " + other.name + " / 때린 놈 : " + this.name);
            health.TakenDamage(fDamage, gameObject.name);
            Destroy(this.gameObject);
        }
    }

}
