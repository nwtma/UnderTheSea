using UnityEngine;
using UnityEditor;

public class SharkHealth : Ai_Health
{
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] public bool isBoss;
    private void Awake()
    {
        slider.maxValue = fHitpoints;
    }

    public override void Update()
    {
        base.Update();
        slider.value = HitPointsRemaining;

        if (!IsAlive && isBoss)
        {
            GameClear();
            ResultManager.instance.Victory(Time.deltaTime);
        }
    }
}