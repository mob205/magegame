using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtoAbilitySlot : MonoBehaviour
{
    public Ability currentAbility;
    SelectionSlot hoveredSlot = null;
    Image slotImage = null;
    [SerializeField] Sprite defaultImage = null;

    private void Start()
    {
        slotImage = GetComponent<Image>();
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && hoveredSlot != null)
        {
            currentAbility = hoveredSlot.ability;
            if (IsAllowedDuplicate(currentAbility, hoveredSlot.maxDuplicates))
            {
                slotImage.sprite = currentAbility.icon;
            }
            else
            {
                ResetSlot();
            }
        }
    }
    bool IsAllowedDuplicate(Ability abilityToAdd, int maxDuplicates)
    {
        var timesFound = 0;
        for (int i = 0; i < AbilitySelector.selectedAbilities.Length; i++)
        {
            if (AbilitySelector.selectedAbilities[i] == currentAbility)
            {
                timesFound++;
            }
        }
        return timesFound <= maxDuplicates;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hoveredSlot = collision.GetComponentInParent<SelectionSlot>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hoveredSlot = null;
    }
    public void ResetSlot()
    {
        currentAbility = null;
        slotImage.sprite = defaultImage;
    }
}
