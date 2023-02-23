using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class ParticleCollision : MonoBehaviour
{

    [SerializeField] float fDamage;

    public void OnParticleCollision(GameObject other)
    {
        if (other.tag != "AI")
        {
            return;
        }

        Destructable destructable = other.transform.GetComponentInChildren<Destructable>();
        var Bullet_ = other.transform.parent;

        if (Bullet_ != null && Bullet_.tag == "Bullet")
        {
            return;
        }

        if (destructable != null)
        {
            //Debug.Log("잘되는거 맞제?");
            //Debug.Log("맞은 놈 : " + other.name);
            //Debug.Log("때린 놈 : " + this.name);
            //Debug.Log("데미지  : " + fDamage);
            destructable.TakenDamage(fDamage, gameObject.name);
            Destroy(this.gameObject);
        }

    }
}