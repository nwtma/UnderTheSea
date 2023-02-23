using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : Destructable
{
    [SerializeField] public GameObject Black;
    [SerializeField] public Animation moug_sk_ui;
    [SerializeField] public Animation hitAnimation;
    [SerializeField] public Slider hp_bar;

    public GameObject HealEffect;
    public Animation healAnimation;

    public string _Bullet_name;
    int spawn_r;
    int playerlayername;
    float mong_time;
    Timerrrr timeer;


    public override void Die()
    {
        Black.SetActive(true);
        timeer.SpawnTime();
        base.Die();

        if (dieCount == 3)
        {
            ResultManager.instance.Defeat();
        }

        if (time < 0.1f)
        {
            this.transform.parent.GetComponent<Character_Audio>().PlayAudio("die", "SE");
        }

        if (time > spawnTime)
        {
            Spawn();
            time = 0;
        }
    }
    public override void TakenDamage(float fAmount, string Bullet_name)
    {
        base.TakenDamage(fAmount, Bullet_name);

        _Bullet_name = Bullet_name;

        if (_Bullet_name == "Indiaink_Ai(Clone)")
        {
            moug_sk_ui.Play();
            this.transform.parent.GetComponent<Character_Audio>().PlayAudio("EnabledSkill", "SE");
        }

        else if (_Bullet_name == "HydroPump_AI(Clone)")
        {
            this.transform.parent.GetComponent<Character_Audio>().PlayAudio("WhaleSkill", "SE");
        }

        else
        {
            this.transform.parent.GetComponent<Character_Audio>().PlayAudio("hit", "SE");
        }

        hitAnimation.Play();
    }
    public virtual void Spawn()
    {
        Black.SetActive(false);
        timeer.time = timeer.Limit;
        spawn_r = Random.Range(0, 5);
        gameObject.transform.parent.position = spawn_p[spawn_r].position;
        fDamageTaken = 0;
    }

    private void Start()
    {
        playerlayername = LayerMask.NameToLayer("Player");
        timeer = gameObject.GetComponent<Timerrrr>();
    }

    private void FixedUpdate()
    {
        Physics.IgnoreLayerCollision(playerlayername, playerlayername);
    }
    private void Update()
    {
        if (!IsAlive)
            Die();

        if (SpawnGroup != null)
        {
            //스폰 그룹의 각 스폰포인트의 위치 확인
            SpawnGroup.GetComponentsInChildren<Transform>(spawn_p);
        }
        else
        {
            SpawnGroup = GameObject.FindGameObjectWithTag("Spawn_P");
        }



        hp_bar.value = hp_bar.maxValue - fDamageTaken;
    }
}