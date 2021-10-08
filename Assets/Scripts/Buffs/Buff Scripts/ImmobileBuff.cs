﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;

public class ImmobileBuff : TickBuff
{
    private readonly Rigidbody2D _rb;
    private readonly ICaster _caster;

    private ParticleSystem particles;
    public ImmobileBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        _rb = obj.GetComponent<Rigidbody2D>();
        _caster = obj.GetComponent<ICaster>();
    }
    protected override void ApplyEffect()
    {
        ScriptableImmobileBuff immobileBuff = (ScriptableImmobileBuff)Buff;
        particles = Object.Instantiate(immobileBuff.ImmobilizedParticles, Obj.transform);
        if (_caster != null) { _caster.CanCast = false; }
    }
    public override void End()
    {
        Object.Destroy(particles);
        if(_caster != null) { _caster.CanCast = true; }
        EffectStacks = 0;
    }
    protected override void ApplyTickEffect()
    {
        _rb.velocity = Vector2.zero;
    }
}
