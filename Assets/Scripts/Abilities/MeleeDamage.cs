using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : Ability
{
    [SerializeField] float damage;

    public override void CastAbility(Transform target)
    {
        var targetHealth = target.GetComponent<Health>();
        if (targetHealth)
        {
            targetHealth.Damage(damage);
            StartCooldown();
        }
    }
}
