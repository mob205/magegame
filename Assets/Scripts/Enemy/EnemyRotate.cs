using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    [SerializeField] GameObject rotator = null;

    Transform player;
    private void Start()
    {
        player = PlayerAbilities.instance.transform;
    }
    void Update()
    {
        rotator.transform.rotation = Utility.GetFacingAngle(transform.position, player.transform.position);
    }
}
