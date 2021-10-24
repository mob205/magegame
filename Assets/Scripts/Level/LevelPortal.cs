using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelPortal : Interactable
{
    [SerializeField] Transform teleportLocation = null;
    [SerializeField] UnityEvent teleportEvent;

    public override void Interact(Collider2D collision)
    {
        if(collision.gameObject == PlayerAbilities.instance.gameObject)
        {
            collision.gameObject.transform.position = teleportLocation.position;
            if (teleportEvent != null)
            {
                teleportEvent.Invoke();
            }
        }
    }
}
