//InputController.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public float Vertical;
    public float Horizontal;
    public Vector2 MouseInput;
    public bool bSkill1;
    public bool bFire1;
    public bool bRun;
    public bool bRunFalse;
    public bool bFire1Down;
    public bool bFire1Up;

    public bool bChargeTime;

    public float fChargeTime;

    void Start()
    {
        bChargeTime = false;
    }

    void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        bSkill1 = Input.GetButton("Skill1");
        bFire1 = Input.GetButton("Fire1");
        bFire1Down = Input.GetButtonDown("Fire1Down");
        bFire1Up = Input.GetButtonUp("Fire1Up");
        bRun = Input.GetButton("Run");
        bRunFalse = Input.GetButtonUp("Run");

        Chargedamage();
    }

    void Chargedamage()
    {
        if(GameManager.Instance.CharacterInt == null)
        {
            return;
        }

        if (GameManager.Instance.CharacterInt.ChargeCA == 1)
        {
            if (bFire1)
            {
                if (bFire1Down)
                {
                    fChargeTime = 0f;
                }
                if (bFire1Up)
                {
                    fChargeTime = 0f;
                }
                fChargeTime += Time.deltaTime;
            }

            if (fChargeTime >= 1.2f)
            {
                bChargeTime = true;
            }

        }

        return;
    }
}
