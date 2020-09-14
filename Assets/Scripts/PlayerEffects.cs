using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour, ISlowable
{
    PlayerMovement movement;
    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }
    void Update()
    {

    }
    public void ApplySlow(float modifier)
    {
        movement.movementSpeed *= modifier;
    }
}
