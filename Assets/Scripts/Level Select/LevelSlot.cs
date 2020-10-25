using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlot : MonoBehaviour
{
    [SerializeField] Sprite unlockedIcon = null;
    [SerializeField] string levelName = null;

    Image image;

    #region Debug Unlock
    bool canDebugUnlock = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            canDebugUnlock = !canDebugUnlock;
        }
    }
    public void DebugUnlock()
    {
        if (!Debug.isDebugBuild || !canDebugUnlock) { return; }
        LevelUnlocker.UnlockLevel(levelName);
        image.sprite = unlockedIcon;
    }
    #endregion
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

}
