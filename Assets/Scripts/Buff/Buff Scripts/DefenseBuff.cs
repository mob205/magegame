using ScriptableObjects;
using UnityEngine;

public class DefenseBuff : TimedBuff
{
    private readonly Health _health;

    public DefenseBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        _health = obj.GetComponent<Health>();
    }

    protected override void ApplyEffect()
    {
        ScriptableDefenseBuff speedBuff = (ScriptableDefenseBuff)Buff;
        _health.damageModifier *= speedBuff.DefenseModifier;
    }

    public override void End()
    {
        ScriptableDefenseBuff speedBuff = (ScriptableDefenseBuff)Buff;
        _health.damageModifier /= speedBuff.DefenseModifier / EffectStacks;
        EffectStacks = 0;
    }
}
