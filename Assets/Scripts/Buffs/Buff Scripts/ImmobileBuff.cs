using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmobileBuff : TickBuff
{
    private readonly Rigidbody2D _rb;
    public ImmobileBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        _rb = obj.GetComponent<Rigidbody2D>();
    }
    protected override void ApplyEffect()
    {
    }
    public override void End()
    {
        EffectStacks = 0;
    }
    protected override void ApplyTickEffect()
    {
        _rb.velocity = Vector2.zero;
    }
}
