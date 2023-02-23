using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Shark : AI
{
    public override void AiAttack()
    {
        base.AiAttack();

        AIweapon.GetAIAttack("Shark");

        SetState(State.Idle);
    }
}