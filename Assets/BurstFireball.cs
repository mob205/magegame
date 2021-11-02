using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstFireball : Ability
{
    [SerializeField] Projectile projectile = null;
    [SerializeField] float projectileDamage = 10;
    [SerializeField] float projectileLifetime = 5;
    [SerializeField] float projectileSpeed = 10;
    [SerializeField] int amount;

    private ICaster _caster;
    private void Start()
    {
        _caster = GetComponentInParent<ICaster>();
    }

    public override void CastAbility(Transform target)
    {
        var degDifference = 360 / amount;
        for(int i = 0; i < amount; i++)
        {
            // Create and fire projectile
            var fireballInstance = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, i * degDifference));
            fireballInstance.GetComponent<Rigidbody2D>().velocity = fireballInstance.transform.right * projectileSpeed;

            // Assign variables in fireball
            fireballInstance.caster = transform.parent.gameObject;
            fireballInstance.damage = projectileDamage * _caster.DamageModifier;

            Destroy(fireballInstance.gameObject, projectileLifetime);
        }



        StartCooldown();
    }
}
