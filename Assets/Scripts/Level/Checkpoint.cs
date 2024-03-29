﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator _animator;
    private CameraFollow _cam;
    [SerializeField] private BoxCollider2D _viewBox;
    bool hasActivated;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _cam = Camera.main.GetComponent<CameraFollow>();
        if (CheckpointStorage.CheckpointLocation == gameObject.transform.position && CheckpointStorage.CheckpointScene == SceneChanger.CurrentScene)
        {
            PlayerAbilities.instance.transform.position = gameObject.transform.position;
            if (_viewBox)
            {
                _cam.SetViewbox(_viewBox);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.isTrigger && !hasActivated)
        {
            CheckpointStorage.SetCheckpoint(this);
            _animator.SetTrigger("Activate");
            var playerHealth = PlayerAbilities.instance.GetComponent<Health>();
            playerHealth.Heal(playerHealth.maxHP);
            hasActivated = true;
        }
    }
}
