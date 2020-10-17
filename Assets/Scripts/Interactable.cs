using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact(collision);
    }
    public virtual void Interact(Collider2D collision)
    {
        Debug.Log("Base interaction not implemented.");
    }
}
