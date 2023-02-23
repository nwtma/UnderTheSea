using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heal : MonoBehaviour
{
    private float cooltime = 15; //힐팩 사용 후 잴 쿨타임
    private float currentCoolTime; //0으로 초기화
    private bool isOnCoolTime; //쿨타임 여부 확인

    [SerializeField] public float healPoint; //치유량
    [SerializeField] public GameObject particle; //조개 반짝이 이펙트

    public GameObject healEffect;
    
    void Update()
    {
        if (isOnCoolTime)
        {
            currentCoolTime += Time.deltaTime;
            if(currentCoolTime >= cooltime)
            {
                currentCoolTime = 0;
                isOnCoolTime = false;
                SetHealEnable(true);
            }
        }
    }

    void SetHealEnable(bool InEnable)
    {
        this.GetComponent<Collider>().enabled = InEnable;
        this.GetComponentsInChildren<MeshRenderer>()[0].enabled = InEnable;
        this.GetComponentsInChildren<MeshRenderer>()[1].enabled = InEnable;
        particle.SetActive(InEnable);
    }

    void OnSuccessedHeal(Health health)
    {
        this.GetComponent<AudioSource>().Play();
        this.GetComponent<AudioSource>().volume = GameObject.Find("Option_Canvas").transform.Find("Window").transform.Find("Option_Window").transform.Find("SE_Slider").GetComponent<Slider>().value;
        SetHealEnable(false);

        isOnCoolTime = true;

        health.HealEffect.SetActive(true);
        health.healAnimation.Play();
        Instantiate(healEffect, this.transform.position, Quaternion.identity);
    }

    bool IsPlayer(Collider col)
    {
        return col.transform.parent.tag == "Player";
    }

    bool IsFullHealth(Health health)
    {
        return health.HitPointsRemaining == health.fHitpoints;
    }

    bool IsOverHeal(Health health)
    {
        return health.HitPointsRemaining + healPoint > health.fHitpoints;
    }

    void OnTriggerEnter(Collider col)
    {
        if (!IsPlayer(col)) //플레이어가 아니라면 동작 안 함
            return;

        Health col_health = col.GetComponentInChildren<Health>();
        if (IsFullHealth(col_health))
            return;

        if (IsOverHeal(col_health))   //접촉한 콜리더의 남은 체력에 치유했을 때 최대 체력보다 클 때
        {
            col_health.fDamageTaken = 0;    //받은 대미지 0으로
        }
        else
        {
            col_health.fDamageTaken -= healPoint;  //받은 대미지 -healPoint
        }

        OnSuccessedHeal(col_health);
    }
}
    