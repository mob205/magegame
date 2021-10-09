using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;
using System.Linq;

public class UnstoppableBuff : TickBuff
{
    private readonly BuffableEntity _buffable;
    public UnstoppableBuff(ScriptableBuff buff, GameObject obj) : base(buff, obj)
    {
        _buffable = obj.GetComponent<BuffableEntity>();
    }
    protected override void ApplyEffect()
    {

    }
    public override void End()
    {

    }
    protected override void ApplyTickEffect()
    {
        var unstoppableBuff = (ScriptableUnstoppableBuff)Buff;
        foreach(var buff in _buffable.GetBuffs())
        {
            if (unstoppableBuff.ImmobilizationBuffs.Contains(buff.Buff))
            {
                buff.IsFinished = true;
                buff.End();
            }
        }
    }
}
