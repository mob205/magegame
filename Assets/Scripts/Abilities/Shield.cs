using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Ability
{
    [SerializeField] float shieldDuration = 5;
    [SerializeField] GameObject shieldObject = null;
    [SerializeField] float followDist = 2;
    Buff castBuff;

    private void Start()
    {
        castBuff = GetComponent<Buff>();
        castBuff.target = GetComponentInParent<Buffable>();
    }
    public override void CastAbility(Transform target)
    {
        // Gets direction from caster to mouse pos.
        Vector2 targetPos = target.position;

        // Create shield object and give it the same tag as caster for the purposes of projectiles.
        var shieldInstance = Instantiate(shieldObject, transform.position, Quaternion.identity, transform);
        shieldInstance.tag = transform.parent.gameObject.tag;

        // Face instance toward mouse
        shieldInstance.transform.rotation = Utility.GetFacingAngle(transform.position, targetPos);

        // Add the following distance offset from caster
        shieldInstance.transform.position += shieldInstance.transform.forward * followDist;

        if (castBuff)
        {
            castBuff.ApplyBuff();
            Debug.Log("Buff applied");
            StartCoroutine(DelayedRemoveBuff());
        }

        Destroy(shieldInstance, shieldDuration);

        StartCooldown();
    }
    IEnumerator DelayedRemoveBuff()
    {
        yield return new WaitForSeconds(shieldDuration);
        castBuff.RemoveBuff();
        Debug.Log("Buff removed");
    }
}
