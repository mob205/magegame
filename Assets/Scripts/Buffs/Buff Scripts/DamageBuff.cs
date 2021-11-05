using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;

public class DamageBuff : TimedBuff
{
    private readonly ICaster _caster;
    private ParticleSystem particles;
    public DamageBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        _caster = obj.GetComponent<ICaster>();
    }
    protected override void ApplyEffect()
    {
        var damageBuff = (ScriptableDamageBuff)Buff;
        _caster.DamageModifier *= damageBuff.DamageModifier;
        if (damageBuff.BuffParticles)
        {
            particles = Object.Instantiate(damageBuff.BuffParticles, Obj.transform);
        }

    }
    public override void End()
    {
        var damageBuff = (ScriptableDamageBuff)Buff;
        _caster.DamageModifier /= damageBuff.DamageModifier;
        if(particles)
            Object.Destroy(particles);
        EffectStacks = 0;
    }
}
