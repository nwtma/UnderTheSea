using UnityEngine;
using UnityEditor;

public class Whale : AI
{
    public override void AiAttack()
    {
        base.AiAttack();

        AIweapon.GetAIAttack("Whale");

        SetState(State.Idle);
    }
}