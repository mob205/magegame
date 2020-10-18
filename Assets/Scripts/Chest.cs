using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Interactable
{
    bool isOpen = false;
    [SerializeField] Sprite openChest = null;
    [SerializeField] Transform openObject = null;
    public override void Interact(Collider2D collision)
    {
        if (!isOpen && collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().sprite = openChest;
            isOpen = true;
            if (openObject != null)
            {
                openObject.gameObject.SetActive(true);
            }

        }
    }
}
