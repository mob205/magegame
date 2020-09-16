using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : Buff
{
    public Buffable target = null;
    public float modifier;
    IMove moveScript;

    public override void ApplyBuff()
    {
        if (isApplied)
        {
            Debug.Log("Buff already applied.");
        }
        if(!target)
        {
            Debug.Log("No target to buff.");
            return;
        } 
        moveScript = target.GetComponent<IMove>();
        if (moveScript == null)
        {
            Debug.Log("No movement script found on target.");
            return;
        }
        moveScript.MoveSpeed *= modifier;
        target.AddBuff(this);
        isApplied = true;
    }
    public override void RemoveBuff()
    {
        if (isApplied)
        {
            moveScript.MoveSpeed /= modifier;
            target.RemoveBuff(this);
            isApplied = false;
        }
        else
        {
            Debug.Log("Buff not applied.");
        }
    }
}
