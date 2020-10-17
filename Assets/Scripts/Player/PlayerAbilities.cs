using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public static PlayerAbilities instance;

    private bool isCasting;
    float remainingCT;
    public static Ability[] Abilities { get; private set; } = new Ability[5];

    // Abilities are scripts attached to children objects of the player object.
    void Awake()
    {
        instance = this;
        Abilities = GetComponentsInChildren<Ability>();
    }
    void Update()
    {
        UpdateCastTime();
        CastAbilities();
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
        for (int i = 0; i < Abilities.Length; i++)
        {
            if (Input.GetAxisRaw("Ability" + i) == 1 && !isCasting && !Abilities[i].activeCooldown)  
            {
                Abilities[i].CastAbility(MouseFollow.mousePos);
                if(Abilities[i].CastTime > 0)
                {
                    StartCastTime(Abilities[i].CastTime);
                }
                Debug.Log("Casting Ability" + i);
            }
        }
    }
    private void StartCastTime(float castTime)
    {
        isCasting = true;
        remainingCT = castTime;
    }
}
