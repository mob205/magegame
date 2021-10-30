using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator _animator;
    private CameraFollow _cam;
    [SerializeField] private BoxCollider2D _viewBox;
    private void Start()
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
            _cam.CenterCamera();
        } 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision.isTrigger)
        {
            CheckpointStorage.SetCheckpoint(this);
            _animator.SetTrigger("Activate");
            var playerHealth = PlayerAbilities.instance.GetComponent<Health>();
            playerHealth.Heal(playerHealth.maxHP);
        }
    }
}
