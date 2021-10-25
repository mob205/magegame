using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator _animator;
    private CameraFollow _cam;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _cam = Camera.main.GetComponent<CameraFollow>();
        if (CheckpointStorage.CheckpointLocation == gameObject.transform.position && CheckpointStorage.CheckpointScene == SceneChanger.CurrentScene)
        {
            PlayerAbilities.instance.transform.position = gameObject.transform.position;
            _cam.CenterCamera();
        } 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.isTrigger)
        {
            CheckpointStorage.SetCheckpoint(this);
            _animator.SetTrigger("Activate");
        }
    }
}
