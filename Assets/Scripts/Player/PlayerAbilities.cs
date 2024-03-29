﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour, ICaster
{

    public static PlayerAbilities instance;

    private bool isCasting;
    public bool CanCast { get; set; } = true;
    public float DamageModifier { get; set; } = 1;
    float remainingCT;
    public static Ability[] Abilities { get; private set; } = new Ability[5];

    // Abilities are scripts attached to children objects of the player object.
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        LoadAbilitiesFromSelector();
    }
    void Update()
    {
        UpdateCastTime();
        CastAbilities();
    }
    public void LoadAbilitiesFromSelector()
    {
        foreach(Ability ability in AbilitySelector.selectedAbilities)
        {
            if(ability)
                Instantiate(ability, transform);
        }
        UpdateAbilities();
    }
    public void UpdateAbilities()
    {
        Abilities = GetComponentsInChildren<Ability>();
        AbilityUI.instance.UpdateAbilityUI();
    }
    // Check for cast times in a way where progress can be monitored
    private void UpdateCastTime()
    {
        if (isCasting)
            remainingCT -= Time.deltaTime;
        if(remainingCT <= 0)
        {
            isCasting = false;
        }
    }
    // Iterate through every active ability. Cast ability if has active input.
    private void CastAbilities()
    {
        if (!CanCast || PauseMenu.IsPaused) { return; }
        for (int i = 0; i < Abilities.Length; i++)
        {
            if (Input.GetAxisRaw("Ability" + i) == 1 && !isCasting && !Abilities[i].activeCooldown)  
            {
                Abilities[i].CastAbility(MouseFollow.mousePos);
                if(Abilities[i].CastTime > 0)
                {
                    StartCastTime(Abilities[i].CastTime);
                }
            }
        }
    }
    private void StartCastTime(float castTime)
    {
        isCasting = true;
        remainingCT = castTime;
    }
}
