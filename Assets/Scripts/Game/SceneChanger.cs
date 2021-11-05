using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static string CurrentScene { get; private set; }
    private void Awake()
    {
        CurrentScene = SceneManager.GetActiveScene().name;
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadLevelFromUnlocker()
    {
        SceneManager.LoadScene(LevelUnlocker.SelectedLevel);
    }
    public void LoadLevelSelecter()
    {
        if(LevelUnlocker.SelectedLevel != null)
        {
            SceneManager.LoadScene("Spell Selector");
        }
    }
}
