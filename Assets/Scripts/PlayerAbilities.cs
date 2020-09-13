using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    static Ability[] abilities = new Ability[5];
    public static Ability[] Abilities
    {
        get { return abilities; }
    }
    // Abilities are in the form of attached scripts to the player GO
    void Awake()
    {
        abilities = GetComponents<Ability>();
    }
    void Update()
    {
        CastAbilities();
    }
    // Iterate through every active ability. Cast ability if has active input.
    private void CastAbilities()
    {
        for (int i = 0; i < abilities.Length; i++)
        {
            if (Input.GetAxisRaw("Ability" + i) == 1) 
            {
                abilities[i].CastAbility();
                Debug.Log("Casting Ability" + i);
            }
        }
    }
}
