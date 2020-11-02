using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPortal : Interactable
{
    [SerializeField] Transform teleportLocation = null;

    public override void Interact(Collider2D collision)
    {
        if(collision.gameObject == PlayerAbilities.instance.gameObject)
        {
            collision.gameObject.transform.position = teleportLocation.position;
        }
    }
}
