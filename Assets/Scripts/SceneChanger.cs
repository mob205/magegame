using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
