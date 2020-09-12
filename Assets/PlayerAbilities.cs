using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    Ability[] abilities = new Ability[5];
    void Start()
    {
        abilities = GetComponents<Ability>();
    }
    void Update()
    {
        CastAbilities();
    }
    private void CastAbilities()
    {
        for (int i = 0; i <= abilities.Length; i++)
        {
            if (Input.GetAxisRaw("Ability" + i) == 1 && abilities[i])  
            {
                abilities[i].CastSpell();
                Debug.Log("Casting spell for Ability" + i);
            }
        }
    }
}
