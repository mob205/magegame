using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Ability
{
    [SerializeField] float shieldDuration = 5;
    [SerializeField] GameObject shieldObject = null;
    [SerializeField] float followDist = 2;

    // Update is called once per frame
    public override void CastAbility(Transform target)
    {
        // Gets direction from player to mouse pos.
        Vector2 targetPos = target.position;
        var direction = (targetPos - (Vector2)transform.position).normalized;

        // Create shield object
        var shieldInstance = Instantiate(shieldObject, transform.position, Quaternion.identity, transform);

        // Face instance toward mouse
        var pivotPos = transform.position;

        targetPos.x -= pivotPos.x;
        targetPos.y -= pivotPos.y;

        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        shieldInstance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Add the following distance offset from player
        shieldInstance.transform.position += shieldInstance.transform.forward * followDist;

        Destroy(shieldInstance, shieldDuration);

        StartCooldown();
    }
}
