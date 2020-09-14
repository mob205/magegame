using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEffect : MonoBehaviour, IEffect<ISlowable>
{
    public void ApplyEffect(ISlowable target, float modifier)
    {
        target.ApplySlow(modifier);
    }
}
