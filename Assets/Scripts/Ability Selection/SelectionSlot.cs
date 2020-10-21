using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionSlot : MonoBehaviour
{
    public Ability ability = null;
    public string abilityName = "Ability not assigned";
    [TextArea] public string description = "Ability not assigned";
    [SerializeField] Image dragImage = null;
    Vector2 dragOffset;
    Camera cam;

    public void Start()
    {
        cam = Camera.main;
        if (ability)
            GetComponent<Image>().sprite = ability.icon;
        dragImage.sprite = ability.icon;
    }
    private void Update()
    {
        CheckSelection();
        Drag();
    }
    //private void LateUpdate()
    //{
    //    CheckSelection();
    //    Drag();
    //}
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
