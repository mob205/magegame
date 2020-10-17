using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehavior : MonoBehaviour
{
    float yOffset;
    Camera cam;
    void Start()
    {
        cam = Camera.main;
        yOffset = transform.position.y - cam.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = new Vector2(transform.position.x, cam.transform.position.y + yOffset);
    }
}
