using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunController : MonoBehaviour
{
    Ray ShootToward;
    RaycastHit rayHit;
    public Vector3 RayPoint;
    public float rayLength;
    public Transform muzzle;
    public Camera theCam;

    private GameObject rayStay;

    public int layer;
    void Start()
    {
        //muzzle = gameObject.transform.Find("Muzzle");
    }

    void Hit()
    {
        ShootToward = new Ray
        {
            origin = theCam.transform.position,
            direction = theCam.transform.forward
        };

        if (Physics.Raycast(ShootToward.origin, ShootToward.direction, out rayHit, rayLength, layer))
        {
            RayPoint = rayHit.point;
            muzzle.transform.LookAt(RayPoint);
        }

        if (GameManager.Instance.CharacterInt.CharacterCA == 1)
        {
            //layer = 11;
            layer = 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Bullet") | 1 << LayerMask.NameToLayer("WallCharacter");
            layer = ~layer;
        }
    }

    void Update()
    {
        Hit();
        Debug.DrawLine(ShootToward.origin, rayHit.point, Color.red);
    }
}
