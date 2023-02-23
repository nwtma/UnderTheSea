using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float fSpeed;
    public float fRange;
    public float fTimeToLive;
    public float fDamage;
    public float fChargeSHT;
    public bool bfDamgeChange;
    [SerializeField] public string Shooter_;
    [SerializeField] public bool isPlayer;
    [SerializeField] public Character_Audio audio;

    public Animator Cross_Anima;

    private int Shark;

    private Rigidbody BulletRB;

    private int SharkDamage;
    private int IndiaDamage;
    
    void Start()
    {
        fChargeSHT = GameManager.Instance.InputController.fChargeTime;

        BulletRB = GetComponent<Rigidbody>();
        Destroy(gameObject, fTimeToLive);

        IndiaFdamage();
    }

    private void FixedUpdate()
    {
        BulletRB.MovePosition(transform.position += transform.forward * fSpeed);
        BulletRB.AddForce((transform.forward * fSpeed) * fRange * Time.deltaTime, ForceMode.VelocityChange);
    }

    public void OnTriggerEnter(Collider other)
    {
        var Bullet_ = other.transform.parent;
        if (Bullet_ != null && Bullet_.tag == "Bullet")
        {
            Destroy(this.gameObject);
            return;
        }

        if (isPlayer)
        {
            Ai_Health ai_health = other.transform.GetComponentInChildren<Ai_Health>();

            if (Cross_Anima != null && ai_health != null)
            {
                Cross_Anima.SetBool("Hit", true);
                audio.PlayAudio("attack", "SE");
                ai_health.TakenDamage(fDamage, gameObject.name);
            }
            
        }

        else
        {
            Health health = other.transform.GetComponentInChildren<Health>();

            if (health != null)
            {
                health.TakenDamage(fDamage, gameObject.name);
            }

        }
        
        Destroy(this.gameObject);
    }

    void IndiaFdamage()
    {
        if (GameManager.Instance.CharacterInt.CharacterIndia == 1)
        {
            if (fChargeSHT >= 1) //&& fChargeSHT <= 2)
            {
                bfDamgeChange = true;
                if (bfDamgeChange)
                {
                    fDamage += 5;
                    IndiaDamage = 1;
                }
            }
            else if (fChargeSHT >= 0 && fChargeSHT < 1)
            {
                if (!bfDamgeChange)
                {
                    if (IndiaDamage == 1)
                    {
                        fDamage -= 5;
                        IndiaDamage = 0;
                    }
                }
            }
            else if (fChargeSHT == 0)
            {
                bfDamgeChange = false;
            }
        }
        return;
    }
}
