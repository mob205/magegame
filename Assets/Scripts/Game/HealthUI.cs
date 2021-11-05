using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    Slider healthBar;
    [SerializeField] Health targetHealth;

    void Start()
    {
        healthBar = GetComponent<Slider>();
    }

    void Update()
    {
        healthBar.value = targetHealth.currentHealth / targetHealth.maxHP;
    }
    public void SetTarget(Health health)
    {
        targetHealth = health;
    }
}
