using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Interactable
{
    [SerializeField] Sprite openChest = null;
    [SerializeField] Transform openObject = null;
    [SerializeField] Ability unlockAbility = null;

    PlayerAbilities player;
    bool isOpen = false;

    private void Start()
    {
        player = PlayerAbilities.instance;
    }
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
            AddUnlockAbility();
            AbilityUnlocker.UnlockAbility(unlockAbility.name);
        }
    }
    void AddUnlockAbility()
    {
        if(PlayerAbilities.Abilities.Length < 5 && !AbilityUnlocker.UnlockedAbilities.Contains(unlockAbility.name)) 
        {
            Instantiate(unlockAbility, player.gameObject.transform);
            player.UpdateAbilities();
        }
    }
}
