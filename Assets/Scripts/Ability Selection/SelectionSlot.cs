using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionSlot : MonoBehaviour
{
    public Ability ability = null;
    public string abilityName = "Ability not assigned";
    [TextArea] public string description = "Ability not assigned";
    public string unlockLocation = "Grassland(1-1)";
    public int maxDuplicates = 0;

    [SerializeField] Image dragImage = null;
    Vector2 dragOffset;
    Camera cam;
    public bool isUnlocked;

    #region Debug Unlock
    bool canDebugUnlock = false;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            canDebugUnlock = !canDebugUnlock;
        }
        if (AbilitySelector.hovered == this && Input.GetMouseButtonDown(0))
        {
            DebugUnlock();
        }
    }
    public void DebugUnlock()
    {
        if (!Debug.isDebugBuild || !canDebugUnlock) { return; }
        AbilityUnlocker.UnlockAbility(abilityName);
        isUnlocked = true;
        DisplayAbilityIcon();
    }
    #endregion
    public void Start()
    {
        cam = Camera.main;
        isUnlocked = AbilityUnlocker.UnlockedAbilities.Contains(ability.name);
        if (isUnlocked)
        {
            DisplayAbilityIcon();
        }
    }
    void DisplayAbilityIcon()
    {
        GetComponent<Image>().sprite = ability.icon;
        dragImage.sprite = ability.icon;
    }
    private void Update()
    {
        CheckSelection();
        if (isUnlocked)
        {
            Drag();
        }
    }
    void Drag()
    {
        if(AbilitySelector.selected == this)
        {
            dragImage.transform.position = Input.mousePosition;
        }
    }
    void CheckSelection()
    {
        if (AbilitySelector.hovered == this && Input.GetMouseButtonDown(0))
        {
            AbilitySelector.selected = this;
        }
        else
        {
            dragImage.transform.position = transform.position;
        }
    }
}
