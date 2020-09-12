using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Ability
{
    [SerializeField] float projectileLifetime;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void CastSpell()
    {
        if (!activeCooldown)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var direction = (mousePos - (Vector2)transform.position).normalized;
            var fireballInstance = Instantiate(projectile, transform.position, Quaternion.LookRotation(direction, Vector3.up));
            fireballInstance.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
            
            StartCoroutine(Cooldown());
        }
    }
}
