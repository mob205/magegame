using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TickBuff : TimedBuff
{
    public TickBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {

    }
    public override void Tick(float delta)
    {
        ApplyTickEffect();
        base.Tick(delta);
    }
    protected abstract void ApplyTickEffect();
}
