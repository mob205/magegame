using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float degPerSecond;
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, degPerSecond * Time.fixedDeltaTime));
    }
}
