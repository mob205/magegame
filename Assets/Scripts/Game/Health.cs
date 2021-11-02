using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHealth = 0;
    public float damageModifier = 1;
    public bool isInvulnerable = false;
    [SerializeField] UnityEvent deathEvent = null;

    void Start()
    {
        currentHealth = maxHP;
    }

    public void Damage(float amount)
    {
        if(isInvulnerable) { return; }

        currentHealth -= amount * damageModifier;
        if (currentHealth <= 0)
        {
            StartDeath();
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHP);
    }

    public void StartDeath()
    {
        gameObject.SetActive(false);
        if (deathEvent != null)
        {
            deathEvent.Invoke();
        }
    }
}
