using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    private void Update()
    {
        isFired();

            //if (GameManager.Instance.InputController.bFire1Up)
            //{
            //    weapon.Fire();
            //}
        if (GameManager.Instance.InputController.bSkill1)
        {
            weapon.IndiaSkill();
            weapon.WhiteSkill();
            weapon.SharkSkill();
            weapon.ClownSkill();
        }
    }

    public bool isFired()
    {
        if (GameManager.Instance.InputController.bFire1)
        {
            weapon.Fire();
            return true;
        }

        return false;
    }
}
