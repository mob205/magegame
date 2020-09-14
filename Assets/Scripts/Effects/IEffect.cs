using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect<T>
{
    void ApplyEffect(T target, float modifier);
}
