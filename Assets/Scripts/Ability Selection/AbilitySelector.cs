using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelector : MonoBehaviour
{
    [SerializeField] ProtoAbilitySlot[] abilitySlots = null;

    public static SelectionSlot hovered;
    public static SelectionSlot selected;

    public static Ability[] selectedAbilities = new Ability[5];

    void Update()
    {
        SelectSlot();
        CheckUnselect();
        GetSelectedAbilities();
    }
    private static void SelectSlot()
    {
        var mousePos = Input.mousePosition;
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector3.forward, Mathf.Infinity);
        if (!hit)
        {
            // Set hovered to null and return if hit = null to prevent null obj reference error.
            hovered = null;
            return;
        }
        var slot = hit.collider.GetComponent<SelectionSlot>();
        // To filter out a ProtoAbilitySlot from being hovered for the purposes of drag and drop.
        if (slot)
        {
            hovered = slot;
        }
        else
        {
            hovered = null;
        }
        // Clear an ability slot if left clicked 
        var abilitySlot = hit.collider.GetComponent<ProtoAbilitySlot>();
        if (abilitySlot && Input.GetMouseButtonDown(0))
        {
            abilitySlot.ResetSlot();
        }
    }
    void CheckUnselect()
    {
        if (Input.GetMouseButtonUp(0))
        {
            selected = null;
        }
    }
    void GetSelectedAbilities()
    {
        for (int i = 0; i < abilitySlots.Length; i++)
        {
            selectedAbilities[i] = abilitySlots[i].currentAbility;
        }
    }
}
