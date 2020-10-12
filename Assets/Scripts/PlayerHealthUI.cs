using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    Slider healthBar;
    Health playerHealth;

    void Start()
    {
        healthBar = GetComponent<Slider>();
        playerHealth = PlayerAbilities.instance.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerHealth.currentHealth / playerHealth.maxHP;
    }
}
