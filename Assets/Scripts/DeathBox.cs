using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : Interactable
{
    public override void Interact(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        if (health)
            health.Damage(9999);
    }
}
