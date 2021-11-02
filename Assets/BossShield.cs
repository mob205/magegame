using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShield : Ability
{
    [SerializeField] float shieldDuration = 5;
    [SerializeField] GameObject shieldObject = null;
    [SerializeField] float followDist = 2;
    [SerializeField] ScriptableBuff castBuff;
    [SerializeField] int amount;

    BuffableEntity buffTarget;
    TimedBuff buff;
    private void Start()
    {
        buffTarget = GetComponentInParent<BuffableEntity>();
    }
    public override void CastAbility(Transform target)
    {
        var degDifference = 360 / amount;
        for(int i = 0; i < amount; i++)
        {
            // Create shield object and give it the same tag as caster for the purposes of projectiles.
            var shieldInstance = Instantiate(shieldObject, transform.position, Quaternion.identity, null);
            shieldInstance.tag = transform.parent.gameObject.tag;
            shieldInstance.SetActive(true);

            // Face instance toward mouse and add the following distance offset from caster
            shieldInstance.transform.SetPositionAndRotation(transform.position + shieldInstance.transform.forward * followDist, Quaternion.Euler(0, 0, i * degDifference));

            if (castBuff)
            {
                buff = castBuff.InitializeBuff(buffTarget.gameObject);
                buffTarget.AddBuff(buff);
            }
            Destroy(shieldInstance, shieldDuration);
        }
        StartCooldown();
    }
    public void OnShieldDestroyed()
    {
        if (buff != null)
        {
            buff.End();
            buff.IsFinished = true;
        }
    }
}
