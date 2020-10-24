using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUI : MonoBehaviour
{
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        if(LevelUnlocker.SelectedLevel != null)
        {
            text.text = LevelUnlocker.SelectedLevel;
        }
    }
}
