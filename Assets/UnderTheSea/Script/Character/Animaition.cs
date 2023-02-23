using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animaition : MonoBehaviour
{
    public Animator animator;

    InputController playerInput;

    void Awake()
    {
        playerInput = GameManager.Instance.InputController;
    }

    bool Wait()
    {
        if (playerInput.Horizontal == 0 && playerInput.Vertical == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool Move()
    {
        if(playerInput.Horizontal != 0 || playerInput.Vertical != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void AnimeWait()
    {
        if(Wait())
        {
            animator.SetBool("Move", false);
            animator.SetBool("Wait", true);
        }
        return;
    }

    void AnimeMove()
    {
        if (Move())
        {
            animator.SetBool("Wait", false);
            animator.SetBool("Move", true);
        }
        return;
    }

    void Update()
    {
        AnimeWait();
        AnimeMove();
    }


}
