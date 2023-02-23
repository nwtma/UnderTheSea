using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Weapon : MonoBehaviour
{
    public float fRateOfFire;

    public Projectile projectile;
    public Projectile projectileskill;

    [SerializeField] private float fTimeToLive;

    private float fNextFireAllowed;
    private float fNextFireSkillAllowed;
    [SerializeField]private float skill;
    public float skill_cool;
    [SerializeField] public float SyangSkill;

    [SerializeField] public Transform[] ai_muzzle;
    public Animator ai_animator;
    private bool isAttack;
    private bool isSharkSkill;

    void Update()
    {
        if (isAttack)
        {
            skill += Time.deltaTime;
        }
    }

    public void GetAIAttack(string name)
    {
        isAttack = true;

        switch (name)
        {
            case "Shark":
                {
                    if (isSharkSkill)
                    {
                        Debug.Log("스킬 사용 중임");
                        break;
                    }

                    if (skill >= skill_cool)
                    {
                        StartCoroutine(Ai_Syangskill());
                    }

                    else
                    {
                        Ai_Fire();
                    }
                }
                break;

            case "Whale":
                {
                    if (skill >= skill_cool)
                    {
                        Ai_skill();
                        skill = 0;
                        isAttack = false;
                    }
                }
                break;

            case "Octopus":
                {
                    if(skill >= skill_cool)
                    {
                        Ai_skill();
                        skill = 0;
                        isAttack = false;
                    }
                }
                break;
        }
    }

    //public IEnumerator AI_Attack(string name)
    //{
    //    skill += Time.deltaTime;
    //    if (skill >= skill_cool)
    //    {
    //        if(name == "Shark")
    //        {
    //            StartCoroutine(Ai_Syangskill());
    //        }

    //        else
    //        {
    //            Ai_skill();
    //        }
    //    }

    //    else if(name == "Shark")
    //    {
    //        Ai_Fire();
    //    }
    //    yield break;
    //}

    public virtual void Ai_Fire()
    {
        if (Time.time < fNextFireAllowed)
            return;

        fNextFireAllowed = Time.time + fRateOfFire;
        projectile.GetComponent<Projectile>().Shooter_ = gameObject.name;

        for (int i = 0; i < ai_muzzle.Length; ++i)
        {
            Instantiate(projectile, ai_muzzle[i].position, ai_muzzle[i].rotation);
        }

        this.transform.parent.GetComponent<Character_Audio>().PlayAudio("shoot", "SE");
    }

    public virtual void Ai_skill()
    {
        if(ai_animator == null)
        {
            return;
        }

        for (int i = 0; i < ai_muzzle.Length; ++i)
        {
            Instantiate(projectileskill, ai_muzzle[i].position, ai_muzzle[i].rotation);
        }

        ai_animator.SetTrigger("Skill");
        skill = 0;
    }

    public ParticleSystem syangEffect;
    public float sharkDuration;

    IEnumerator Ai_Syangskill()
    {
        isSharkSkill = true;
        SyangSkill += Time.deltaTime;
        
        //fRateOfFire = 0.7f;

        if (Time.time < fNextFireSkillAllowed)
            yield return null;

        fNextFireSkillAllowed = Time.time + fRateOfFire;

        projectileskill.GetComponent<Projectile>().Shooter_ = gameObject.name;
        
        syangEffect.Play();
        //while (SyangSkill <= sharkDuration)
        //{
            
        //}

        Instantiate(projectileskill, ai_muzzle[0].position, ai_muzzle[0].rotation);

        //ai_animator.Play("Skill", -1, 0);

        SyangSkill = 0;
        syangEffect.Stop();
        

        skill = 0;
        isAttack = false;
        isSharkSkill = false;
        yield break;
    }
}