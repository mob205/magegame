using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHP = 100;
    private float currentHealth = 0;

    void Start()
    {
        currentHealth = maxHP;
    }

    public void Damage(float amount)
    {
        currentHealth -= amount;
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
        Destroy(gameObject);
    }
}
