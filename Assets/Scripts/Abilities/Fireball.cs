using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Ability
{
    [SerializeField] Projectile projectile = null;
    [SerializeField] float projectileDamage = 10;
    [SerializeField] float projectileLifetime = 5;
    [SerializeField] float projectileSpeed = 10;

    private ICaster _caster;
    private void Start()
    {
        _caster = GetComponentInParent<ICaster>();
    }

    public override void CastAbility(Transform target)
    {

        // Create and fire projectile
        var fireballInstance = Instantiate(projectile, transform.position, Utility.GetFacingAngle(transform.position, target.position));
        fireballInstance.GetComponent<Rigidbody2D>().velocity = fireballInstance.transform.right * projectileSpeed;
        
        // Assign variables in fireball
        fireballInstance.caster = transform.parent.gameObject;
        fireballInstance.damage = projectileDamage * _caster.DamageModifier;

        Destroy(fireballInstance.gameObject, projectileLifetime);

        StartCooldown();
    }
}
