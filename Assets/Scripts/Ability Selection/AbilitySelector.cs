using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelector : MonoBehaviour
{
    public static SelectionSlot hovered;
    public static SelectionSlot selected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        SelectSlot();
        CheckUnselect();
    }
    void CheckUnselect()
    {
        if (Input.GetMouseButtonUp(0))
        {
            selected = null;
        }
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
    }
}
