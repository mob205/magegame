using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public float damage = 0;
    [HideInInspector] public GameObject caster = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(caster == collision.gameObject)) 
        {
            var hitHealth = collision.GetComponent<Health>();
            if (hitHealth)
            {
                hitHealth.Damage(damage);
                Destroy(gameObject);
            }
        }
    }
}
