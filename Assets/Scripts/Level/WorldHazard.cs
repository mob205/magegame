using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldHazard : MonoBehaviour
{
    [SerializeField] private float ticksPerSecond;
    [SerializeField] private float damagePerTick;

    private bool _canDamage;
    private void OnEnable()
    {
        _canDamage = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger && collision.CompareTag("Player")) 
        {
            var health = collision.GetComponent<Health>();
            if(health && _canDamage)
            {
                health.Damage(damagePerTick);
                StartCoroutine(TickCooldown());
            }
        }
    }
    private IEnumerator TickCooldown()
    {
        _canDamage = false;
        yield return new WaitForSeconds(1 / ticksPerSecond);
        _canDamage = true;
    }
}
