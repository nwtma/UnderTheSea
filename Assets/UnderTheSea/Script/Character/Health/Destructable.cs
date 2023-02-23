using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    //체력 한계
    public float fHitpoints;
    //받은 데미지
    public float fDamageTaken;

    public event System.Action OnDamageReceived;

    protected float time;
    public float spawnTime;

    public List<Transform> spawn_p;
    [SerializeField]public GameObject SpawnGroup;
    [SerializeField] protected int dieCount;
    

    //체력
    public float HitPointsRemaining
    {
        get
        {
            return fHitpoints - fDamageTaken;
        }

    }

    public bool IsAlive
    {
        get
        {
            return HitPointsRemaining > 0;
        }
    }


    public GameObject Damage_effect;    //피격 이펙트 프리팹
    public virtual void TakenDamage(float fAmount, string Bullet_name)
    {
        Vector3 pos = new Vector3(this.transform.position.x + 1, this.transform.position.y + 1, this.transform.position.z);

        fDamageTaken += fAmount;
        Instantiate(Damage_effect, pos, Quaternion.identity);
        

        if (HitPointsRemaining <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {

        if (IsAlive)
            return;

        //this.transform.parent.GetComponent<Character_Audio>().PlayAudio("die", "SE");

        gameObject.transform.parent.position = new Vector3(0, 0, 1000);

        if(time == 0)
        {
            dieCount += 1;
        }

        time += Time.deltaTime;
    }
}
