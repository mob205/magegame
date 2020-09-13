using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Ability
{
    [SerializeField] float projectileLifetime;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed;

    public override void CastAbility()
    {
        if (!activeCooldown)
        {
            // Gets direction from player to mouse pos.
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var direction = (mousePos - (Vector2)transform.position).normalized;

            // Create and fire projectile
            var fireballInstance = Instantiate(projectile, transform.position, Quaternion.LookRotation(direction, Vector3.up));
            fireballInstance.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

            Destroy(fireballInstance, projectileLifetime);

            StartCooldown();
        }
    }
}
