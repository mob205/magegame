using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlot : MonoBehaviour
{
    [SerializeField] Sprite unlockedIcon = null;
    [SerializeField] string levelName = null;

    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        if(LevelUnlocker.UnlockedLevels.Contains(levelName))
        {
            image.sprite = unlockedIcon;
        }
    }
    public void OnSelect()
    {
        LevelUnlocker.SelectLevel(levelName);
    }
    void Update()
    {
        
    }
}
