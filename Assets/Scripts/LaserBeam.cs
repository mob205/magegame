using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public float damagePerTick = 10;
    public int ticksPerSecond = 1;
    public GameObject caster = null;

    List<Health> entities = new List<Health>();
    float timer;
    private void Start()
    {
        timer = (1f / ticksPerSecond);
    }
    // Adds/removes objects to list upon entering/leaving beam
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(caster == collision.gameObject))
        {
            var hitHealth = collision.GetComponent<Health>();
            if (hitHealth && !entities.Contains(hitHealth)) { entities.Add(hitHealth); }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!(caster == collision.gameObject))
        {
            var hitHealth = collision.GetComponent<Health>();
            if (hitHealth && entities.Contains(hitHealth)) { entities.Remove(hitHealth); }
        }
    }
    // Tick timer
    void Update()
    {
        if(timer > (1f / ticksPerSecond))
        {
            timer = 0;
            DamageEntities();
        }
        timer += Time.deltaTime;
    }
    // Iterates over list of entities currently within trigger collider. 
    // (ToArray makes a temporary copy so changes during iteration does not affect it (i.e. if entity dies))
    void DamageEntities()
    {
        foreach (Health entity in entities.ToArray())
        {
            entity.Damage(damagePerTick);
        }
    }
}
