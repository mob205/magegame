using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFace : MonoBehaviour
{
    Transform player = null;

    void Start()
    {
        player = PlayerAbilities.instance.transform;
    }

    void Update()
    {
        int rotAngle;
        if((player.position.x - transform.position.x) > 0)
        {
            rotAngle = 0;
        } else
        {
            rotAngle = 180;
        }
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, rotAngle, transform.rotation.z));
    }
}
