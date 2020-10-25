using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPortal : Interactable
{
    [SerializeField] string unlockedLevelName = null;
    [SerializeField] string interactScene = "Victory";

    void Start()
    {
        
    }
    public override void Interact(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelUnlocker.UnlockLevel(unlockedLevelName);
            SceneManager.LoadScene(interactScene);
            Debug.Log(LevelUnlocker.UnlockedLevels[1]);
        }
    }
    void Update()
    {
        
    }
}
