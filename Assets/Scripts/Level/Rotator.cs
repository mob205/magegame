﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float degPerSecond;

    private Quaternion initialRot;
    private void Start()
    {
        initialRot = transform.rotation;
    }
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, degPerSecond * Time.fixedDeltaTime));
    }
    public void ResetRotation()
    {
        transform.rotation = initialRot;
    }
}
