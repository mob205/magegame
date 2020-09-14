using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    static Ability[] abilities = new Ability[5];
    private bool isCasting;
    float remainingCT;
    public static Ability[] Abilities
    {
        get { return abilities; }
    }
    // Abilities are scripts attached to children objects of the player object.
    void Awake()
    {
        abilities = GetComponentsInChildren<Ability>();
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
        for (int i = 0; i < abilities.Length; i++)
        {
            if (Input.GetAxisRaw("Ability" + i) == 1 && !isCasting && !abilities[i].activeCooldown)  
            {
                abilities[i].CastAbility();
                if(abilities[i].CastTime > 0)
                {
                    StartCastTime(abilities[i].CastTime);
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
