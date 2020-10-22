using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelector : MonoBehaviour
{
    public static SelectionSlot hovered;
    public static SelectionSlot selected;

    ProtoAbilitySlot[] abilitySlots = new ProtoAbilitySlot[5];
    public static Ability[] selectedAbilities = new Ability[5];

    void Start()
    {
        abilitySlots = FindObjectsOfType<ProtoAbilitySlot>();
    }

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
            hovered = null;
            return;
        }
        var slot = hit.collider.GetComponent<SelectionSlot>();
        if (slot)
        {
            hovered = slot;
        }
        var abilitySlot = hit.collider.GetComponent<ProtoAbilitySlot>();
        if (abilitySlot && Input.GetMouseButtonDown(0))
        {
            abilitySlot.Reset();
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
            //if (selectedAbilities[i])
            //    Debug.Log("Slot " + i + ": " + selectedAbilities[i].name);
        }
    }
}
