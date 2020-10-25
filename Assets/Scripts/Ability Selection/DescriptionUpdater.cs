using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionUpdater : MonoBehaviour
{
    [SerializeField] Image descImage = null;
    [SerializeField] Text nameText = null;
    [SerializeField] Text descText = null;

    Sprite defaultSprite;
    SelectionSlot displayedSlot;
    void Start()
    {
        defaultSprite = descImage.sprite;
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
        if (displayedSlot.isUnlocked)
        {
            descImage.sprite = displayedSlot.ability.icon;
            nameText.text = displayedSlot.abilityName;
            descText.text = displayedSlot.description;
        }
        else
        {
            descImage.sprite = defaultSprite;
            nameText.text = "???";
            descText.text = "This ability is hidden in " + displayedSlot.unlockLocation;
        }
    }
}
