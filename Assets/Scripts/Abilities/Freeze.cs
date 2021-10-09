using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Ability
{
    [SerializeField] float damage;
    [SerializeField] float freezeDuration;
    [SerializeField] float radius;
    [SerializeField] ScriptableBuff freezeBuff;

    GameObject caster;
    ParticleSystem particles;
    private void Start()
    {
        caster = transform.parent.gameObject;
        particles = GetComponent<ParticleSystem>();
    }
    public override void CastAbility(Transform target)
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(var hit in hits)
        {
            if (caster.CompareTag(hit.tag) || !hit.isTrigger) { continue; }
            var hitHealth = hit.GetComponent<Health>();
            var buffableEntity = hit.GetComponent<BuffableEntity>();

            if (hitHealth)
            {
                var modifiedDamage = damage * caster.GetComponent<ICaster>().DamageModifier;
                hitHealth.Damage(modifiedDamage);
            }

            if (buffableEntity) 
            {
                freezeBuff.Duration = freezeDuration;
                buffableEntity.AddBuff(freezeBuff.InitializeBuff(buffableEntity.gameObject));
            }
        }
        StartCooldown();
        particles.Play();
    }
}
