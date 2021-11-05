using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkTransformation : Ability
{
    [SerializeField] ScriptableBuff[] buffs;
    private BuffableEntity buffableEntity;
    private Animator animator;
    private void Start()
    {
        buffableEntity = GetComponentInParent<BuffableEntity>();
        animator = GetComponentInParent<Animator>();
        foreach(var buff in buffs)
        {
            buffableEntity.AddBuff(buff.InitializeBuff(buffableEntity.gameObject));
        }
        animator.SetBool("DarkTransformation", true);
    }
    public override void CastAbility(Transform target)
    {

    }
}
