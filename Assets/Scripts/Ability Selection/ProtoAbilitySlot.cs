using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtoAbilitySlot : MonoBehaviour
{
    public Ability currentAbility;
    SelectionSlot hoveredSlot = null;
    Image slotImage = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && hoveredSlot != null)
        {
            currentAbility = hoveredSlot.ability;
            slotImage.sprite = currentAbility.icon;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        hoveredSlot = collision.GetComponentInParent<SelectionSlot>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("no longer triggered");
        hoveredSlot = null;
    }
}
