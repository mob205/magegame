using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Ability
{
    [SerializeField] float shieldDuration = 5;
    [SerializeField] GameObject shieldObject = null;
    [SerializeField] float followDist = 2;
    [SerializeField] ScriptableBuff castBuff;

    BuffableEntity buffTarget;
    private void Start()
    {
        buffTarget = GetComponentInParent<BuffableEntity>();
    }
    public override void CastAbility(Transform target)
    {
        // Gets direction from caster to mouse pos.
        Vector2 targetPos = target.position;

        // Create shield object and give it the same tag as caster for the purposes of projectiles.
        var shieldInstance = Instantiate(shieldObject, transform.position, Quaternion.identity, transform);
        shieldInstance.tag = transform.parent.gameObject.tag;

        
        // Face instance toward mouse and add the following distance offset from caster
        shieldInstance.transform.SetPositionAndRotation(transform.position + shieldInstance.transform.forward * followDist, Utility.GetFacingAngle(transform.position, targetPos));

        if (castBuff)
        {
            buffTarget.AddBuff(castBuff.InitializeBuff(buffTarget.gameObject));
        }

        Destroy(shieldInstance, shieldDuration);

        StartCooldown();
    }
}
