using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossRoom : MonoBehaviour
{
    private bool isActive;
    private CameraFollow cam;
    private BoxCollider2D roomBounds;

    [SerializeField] private float roomCamSize;
    [SerializeField] GameObject bossHealthBar;
    [SerializeField] UnityEvent bossDeathEvent = null;

    private void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>();
        roomBounds = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActive)
        {
            cam.SetViewbox(roomBounds);
            cam.SetCameraSize(roomCamSize);
            cam.CenterCamera();
            bossHealthBar.SetActive(true);
            isActive = true;
        }
    }
    public void OnBossDeath()
    {
        if(bossDeathEvent != null)
        {
            bossDeathEvent.Invoke();
        }
    }
}
