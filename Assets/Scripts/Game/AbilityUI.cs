using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    public static AbilityUI instance;

    [SerializeField] Image[] abilitySlots = new Image[5];
    Slider[] cooldownTimers;
    Ability[] abilities;

    private void Awake()
    {
        instance = this;
    }
    public void UpdateAbilityUI()
    {
        abilities = PlayerAbilities.Abilities;
        cooldownTimers = new Slider[abilities.Length];

        // Display each ability's sprite in the UI bar and get their cooldown timer UI.
        for (int i = 0; i < abilities.Length; i++)
        {
            abilitySlots[i].sprite = abilities[i].icon;
            cooldownTimers[i] = abilitySlots[i].GetComponentInChildren<Slider>();
        }
    }
    void Update()
    {
        // Set cooldown timer to % of cooldown remaining.
        for (int i = 0; i < abilities.Length; i++)
        {
            cooldownTimers[i].value = abilities[i].remainingCD / abilities[i].Cooldown;
        }
    }
}
