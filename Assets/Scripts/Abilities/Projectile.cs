using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public float damage = 0;
    [HideInInspector] public GameObject caster = null;
    [SerializeField] ScriptableBuff hitDebuff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (caster == null || !collision.CompareTag(caster.tag)) 
        {
            var hitHealth = collision.GetComponent<Health>();
            if (hitHealth)
            {
                OnSuccessfulHit(collision, hitHealth);
            }
        }
    }
    protected virtual void OnSuccessfulHit(Collider2D collision, Health hitHealth)
    {
        hitHealth.Damage(damage);
        Destroy(gameObject);
        var hitBuffable = collision.GetComponent<BuffableEntity>();
        if (hitDebuff && hitBuffable)
        {
            hitBuffable.AddBuff(hitDebuff.InitializeBuff(hitBuffable.gameObject));
        }
    }
}
