using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
    // Gets the angle an object must rotate to face a point using arctangent.
    public static Quaternion GetFacingAngle(Vector2 original, Vector2 target)
    {
        target.x -= original.x;
        target.y -= original.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
