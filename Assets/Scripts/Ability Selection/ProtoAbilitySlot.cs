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
        // Checks for mouse release when there is a dragged Slot in the drop range.
        if (Input.GetMouseButtonUp(0) && hoveredSlot != null)
        {
            if (IsAllowedDuplicate(hoveredSlot.ability, hoveredSlot.maxDuplicates))
            {
                SetAbility(hoveredSlot.ability);
            }
        }
    }
    public void SetAbility(Ability ability)
    {
        currentAbility = ability;
        slotImage.sprite = ability.icon;
    }
    bool IsAllowedDuplicate(Ability abilityToAdd, int maxDuplicates)
    {
        var timesFound = 0;
        for (int i = 0; i < AbilitySelector.selectedAbilities.Length; i++)
        {
            if (AbilitySelector.selectedAbilities[i] == abilityToAdd)
            {
                timesFound++;
            }
        }
        return timesFound <= maxDuplicates;
    }
    // Detect when a dragged SelectionSlot object is in drop range.
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
