using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHealth = 0;
    [SerializeField] bool isInvulnerable = false;

    void Start()
    {
        currentHealth = maxHP;
    }

    public void Damage(float amount)
    {
        if(isInvulnerable) { return; }

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
        gameObject.SetActive(false);
    }
}
