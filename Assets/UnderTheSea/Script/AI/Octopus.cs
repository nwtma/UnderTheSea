using UnityEngine;
using UnityEditor;

public class Octopus : AI
{
    public override void AiAttack()
    {
        base.AiAttack();

        AIweapon.GetAIAttack("Octopus");

        SetState(State.Idle);
    }
}