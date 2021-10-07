using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Ability
{
    [SerializeField] float damage;
    [SerializeField] float freezeDuration;
    [SerializeField] float radius;
    [SerializeField] Buff freezeBuff;

    public override void CastAbility(Transform target)
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(var hit in hits)
        {
            if(hit.tag == gameObject.tag) { return; }
            var hitHealth = hit.GetComponent<Health>();
            var hitBuff = hit.GetComponent<Buffable>();

            if (hitHealth)
            {
                hitHealth.Damage(damage);
            }

            if (hitBuff) 
            {
                freezeBuff.target = hitBuff;
                freezeBuff.ApplyBuff();
            }
        }
    }
}
