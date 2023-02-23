using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weapon : MonoBehaviour
{
    [SerializeField] private float fRateOfFire;
    [SerializeField] public float fRateOfSkillFire;
    [SerializeField] private float fTimeToLive;

    [SerializeField] private Projectile projectile;
    [SerializeField] private Projectile projectileskill;

    [SerializeField] public Transform muzzle;

    private float fNextFireAllowed;
    private float fNextFireSkillAllowed;
    private float mongskill;
    private float goraskill;
    private float SyangSkill;

    private float time_ = 0;

    public bool bUseIndiaSkill = false;
    public bool bUseWhiteSkill = false;
    public bool bUseSharkSkill = false;
    public bool bUseClownSkill = false;

    public bool bUsedSkill = false;

    public bool bCanFire;

    private string Shooter_name;
    private int sharkskillused;

    public Slider Skill_Bar;
    public GameObject shark_sk_ui;
    public Animator Cross_Anima;
    [SerializeField] private Character_Audio character_Audio;
    float Hit_time;

    public Animator animator;

    void Awake()
    {
        projectile.GetComponent<Projectile>().Shooter_ = gameObject.name;

        if(this.transform.parent.name != "fish")
        projectileskill.GetComponent<Projectile>().Shooter_ = gameObject.name;

        projectile.GetComponent<Projectile>().Cross_Anima = Cross_Anima;
        projectileskill.GetComponent<Projectile>().Cross_Anima = Cross_Anima;

        character_Audio = this.transform.parent.GetComponent<Character_Audio>();
        projectile.GetComponent<Projectile>().audio = character_Audio;
        projectileskill.GetComponent<Projectile>().audio = character_Audio;
    }

    public virtual void IndiaSkill()
    {
        if (GameManager.Instance.CharacterInt.CharacterIndia == 1)
        {
            if (bUseIndiaSkill)
            {
                if (GameManager.Instance.InputController.bSkill1)
                {
                    if (Time.time < fNextFireSkillAllowed)
                        return;

                    fNextFireSkillAllowed = Time.time + fRateOfSkillFire;
                    //슬라이더에 스킬쿨 넣어줌
                    Skill_Bar.value = fRateOfSkillFire;

                    animator.SetTrigger("Skill");

                    Instantiate(projectileskill, muzzle.position, muzzle.rotation);
                    this.transform.parent.GetComponent<Character_Audio>().PlayAudio("UseSkill", "SE");

                    this.transform.parent.GetComponent<Character_Audio>().PlayAudio("UseSkill", "SE");

                    bUsedSkill = true;
                }
            }
        }
        return;
    }

    public virtual void WhiteSkill()
    {
        if (GameManager.Instance.CharacterInt.CharacterWhite == 1)
        {
            if (bUseWhiteSkill)
            {
                if (GameManager.Instance.InputController.bSkill1)
                {

                    if (Time.time < fNextFireSkillAllowed)
                        return;

                    fNextFireSkillAllowed = Time.time + fRateOfSkillFire;

                    Skill_Bar.value = fRateOfSkillFire;

                    Instantiate(projectileskill, muzzle.position, muzzle.rotation);
                    animator.SetTrigger("Skill");

                    this.transform.parent.GetComponent<Character_Audio>().PlayAudio("UseSkill", "SE");

                    bUsedSkill = true;
                }
            }
        }
        return;
    }

    public GameObject syang_effect;
    public virtual void SharkSkill()
    {
        if (GameManager.Instance.CharacterInt.CharacterShark == 1)
        {
            if (bUseSharkSkill)
            {
                if (GameManager.Instance.InputController.bSkill1)
                {
                    if (Time.time < fNextFireSkillAllowed)
                        return;

                    fNextFireSkillAllowed = Time.time + fRateOfSkillFire;

                    Skill_Bar.value = fRateOfSkillFire;

                    animator.SetTrigger("SkillOn");

                    syang_effect.SetActive(true);
                    shark_sk_ui.SetActive(true);

                    sharkskillused = 1;

                    this.transform.parent.GetComponent<Character_Audio>().PlayAudio("UseSkill", "SE");

                    bUsedSkill = true;
                }
            }
        }
        return;

    }
    /*---------힌동 스킬---------*/
    //힌동 스킬에 필요한 오브젝트 선언
    public bool Ane_Enter;
    Teleport tp;

    public ParticleSystem effect;

    public virtual void ClownSkill()
    {
        if (GameManager.Instance.CharacterInt.CharacterFish == 1)
        {
            tp = FindObjectOfType<Teleport>();

            if (bUseClownSkill)
            {
                if (!Ane_Enter)
                {
                    return;
                }

                else if (Ane_Enter && GameManager.Instance.InputController.bSkill1)
                {
                    bUsedSkill = true;

                    if (Time.time < fNextFireSkillAllowed)
                        return;

                    fNextFireSkillAllowed = Time.time + fRateOfSkillFire;
                    //슬라이더에 스킬쿨 넣어줌
                    Skill_Bar.value = fRateOfSkillFire;
                    tp.SearchRandomTransform();
                    this.transform.parent.GetComponent<Character_Audio>().PlayAudio("UseSkill", "SE");

                    effect.Play();
                    return;
                }
            }
        }
    }
    /*---------힌동 스킬---------*/
    


    public virtual bool Fire()
    {
        if (GameManager.Instance.CharacterInt.ChargeCA == 1)
        {
            if (bCanFire)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    if (Time.time < fNextFireAllowed)
                        return false;

                    fNextFireAllowed = Time.time + fRateOfFire;

                    if (sharkskillused == 1)
                        Instantiate(projectileskill, muzzle.position, muzzle.rotation);
                    else
                        Instantiate(projectile, muzzle.position, muzzle.rotation);

                    this.transform.parent.GetComponent<Character_Audio>().PlayAudio("shoot", "SE");

                    return true;
                }
            }
        }
        else if (GameManager.Instance.CharacterInt.ChargeCA == 0)
        {
            if (bCanFire)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))//GameManager.Instance.InputController.bFire1
                {


                    if (Time.time < fNextFireAllowed)
                        return false;

                    fNextFireAllowed = Time.time + fRateOfFire;
                    //Instantiate(projectile, muzzle.position, muzzle.rotation);

                    if (sharkskillused == 1)
                        Instantiate(projectileskill, muzzle.position, muzzle.rotation);
                    else
                        Instantiate(projectile, muzzle.position, muzzle.rotation);

                    this.transform.parent.GetComponent<Character_Audio>().PlayAudio("shoot", "SE");

                    return true;
                }
            }
        }

        return false;
    }

    void Update()
    {
        //if (bUseProjectileskill)
        //    projectileskill.transform.position = muzzle.position;

        //if (!bUseSharkSkill)
        //{
        //    projectile.tag = "Bullet";
        //}

        if (Skill_Bar.value > 0)
        {
            Skill_Bar.value -= Time.deltaTime;
        }

        if (shark_sk_ui != null && shark_sk_ui.activeSelf == true)
            time_ += Time.deltaTime;

        if (time_ > 5)
        {
            animator.SetTrigger("SkillOff");
            syang_effect.SetActive(false);
            shark_sk_ui.SetActive(false);
            //projectile.tag = "Bullet";
            sharkskillused = 0;
            time_ = 0;
        }

        if (GameManager.Instance.InputController.bFire1Up)
        {
            GameManager.Instance.InputController.fChargeTime = 0;
        }

        if(Cross_Anima.GetBool("Hit") == true)
        {
            Hit_time += Time.deltaTime;
            if(Hit_time >= 1)
            {
                Cross_Anima.SetBool("Hit", false);
                Hit_time = 0;
            }
        }
    }
}
