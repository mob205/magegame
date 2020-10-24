using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionUpdater : MonoBehaviour
{
    [SerializeField] Image descImage = null;
    [SerializeField] Text nameText = null;
    [SerializeField] Text descText = null;

    SelectionSlot displayedSlot;
    void Start()
    {
        
    }

    void Update()
    {
        SelectionSlot selected = AbilitySelector.selected;
        if(selected != null && selected != displayedSlot)
        {
            displayedSlot = selected;
            UpdateDisplay();
        }
    }
    void UpdateDisplay()
    {
        descImage.sprite = displayedSlot.ability.icon;
        nameText.text = displayedSlot.abilityName;
        descText.text = displayedSlot.description;
    }
}
