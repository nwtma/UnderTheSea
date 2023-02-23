using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Animaition : MonoBehaviour
{
    public Animator ai_animator;

    void ai_Move()
    {
        ai_animator.SetBool("Move", true);
    }

    void Update()
    {
        ai_Move();
    }
}
