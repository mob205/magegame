using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPortal : Interactable
{
    [SerializeField] string[] unlockedLevelNames = null;
    [SerializeField] string interactScene = "Victory";

    public override void Interact(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach(var level in unlockedLevelNames)
            {
                LevelUnlocker.UnlockLevel(level);
            }
            SceneManager.LoadScene(interactScene);
        }
    }
}
