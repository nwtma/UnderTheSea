using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai_Health : Destructable
{
    int spawn_r;

    NavMeshAgent age;
    [SerializeField] public Ai_Weapon weapon;

    int AI_layername;
    

    public override void Die()
    {
        base.Die();

        if (time < 0.1f)
        {
            this.transform.parent.GetComponent<Character_Audio>().PlayAudio("die", "SE");
        }
        age.enabled = false;
        if (time > spawnTime)
        {
            Spawn();
            time = 0;
        }
    }

    public virtual void Spawn()
    {
        spawn_r = Random.Range(1, 5);

        gameObject.transform.parent.position = spawn_p[spawn_r].position;
        fDamageTaken = 0;
        age.enabled = true;
    }
    void Start()
    {
        AI_layername = LayerMask.NameToLayer("AI");

        age = gameObject.transform.parent.GetComponent<NavMeshAgent>();
        SpawnGroup = GameObject.FindGameObjectWithTag("Spawn_P");
    }

    void FixedUpdate()
    {
        Physics.IgnoreLayerCollision(AI_layername, AI_layername, true);
    }

    public virtual void Update()
    {
        if (!IsAlive)
        {
            Die();
        }
        if (SpawnGroup != null)
        {
            //스폰 그룹의 각 스폰포인트의 위치 확인
            SpawnGroup.GetComponentsInChildren<Transform>(spawn_p);
        }
    }

    public void GameClear()
    {
        age.enabled = false;
        weapon.fRateOfFire = 10f;
    }
    
}