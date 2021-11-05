using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused { get; private set; }
    [SerializeField] GameObject menu;

    private void Start()
    {
        IsPaused = false;
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            menu.SetActive(!menu.activeSelf);
            TogglePause();
        }   
    }
    public void TogglePause()
    {
        IsPaused = !IsPaused;
        Time.timeScale = Convert.ToInt32(!IsPaused);
    }
}
