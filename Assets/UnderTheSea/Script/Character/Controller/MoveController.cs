using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    Rigidbody rigid;
    Vector3 vet3;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    public void Move(Vector2 direction)
    {
        rigid.MovePosition(transform.position += transform.forward * direction.x * Time.deltaTime + transform.right * direction.y * Time.deltaTime);
        //animator.Play("Move", -1, 0);
    }
}
