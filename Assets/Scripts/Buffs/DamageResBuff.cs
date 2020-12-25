using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageResBuff : Buff
{
    public float modifier;
    Health healthScript;
    public override void ApplyBuff()
    {
        if (isApplied)
        {
            Debug.Log("Buff already applied.");
        }
        if (!target)
        {
            Debug.Log("No target to buff.");
            return;
        }
        healthScript = target.GetComponent<Health>();
        if (healthScript == null)
        {
            Debug.Log("No movement script found on target.");
            return;
        }
        healthScript.damageModifier *= modifier;
        target.AddBuff(this);
        isApplied = true;
    }
    public override void RemoveBuff()
    {
        if (isApplied)
        {
            healthScript.damageModifier /= modifier;
            target.RemoveBuff(this);
            isApplied = false;
        }
        else
        {
            Debug.Log("Buff not applied.");
        }
    }
}
