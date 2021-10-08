using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFire : Ability
{
    [SerializeField] ScriptableBuff damageBoostBuff;
    [SerializeField] ScriptableBuff unstoppableBuff;

    BuffableEntity buffTarget;
    private void Start()
    {
        buffTarget = GetComponentInParent<BuffableEntity>();
    }
    public override void CastAbility(Transform target)
    {
        buffTarget.AddBuff(damageBoostBuff.InitializeBuff(buffTarget.gameObject));
        buffTarget.AddBuff(unstoppableBuff.InitializeBuff(buffTarget.gameObject));
    }
}
