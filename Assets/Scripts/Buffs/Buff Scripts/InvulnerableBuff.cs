using ScriptableObjects;
using UnityEngine;

public class InvulnerableBuff : TimedBuff
{
    private readonly Health _health;

    public InvulnerableBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        _health = obj.GetComponent<Health>();
    }

    protected override void ApplyEffect()
    {
        _health.isInvulnerable = true;
    }

    public override void End()
    {
        _health.isInvulnerable = false;
        EffectStacks = 0;
    }
}
