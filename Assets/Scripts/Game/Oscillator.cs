using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector2 distance = new Vector2(0, 0);
    [SerializeField] float speed = 1;
    Vector2 startPos;
    float startTime;
    private void OnEnable()
    {
        if(startPos == new Vector2(0, 0))
        {
            startPos = transform.position;
        }
        transform.position = startPos;
        startTime = Time.time;
    }
    private void Update()
    {
        // Oscillate factor calculated through a sine function of time.
        // 0.5f(x)+0.5 makes the range of f(x) 0 to 1 so it is usable by the Lerp function.
        // Subtraction of pi / 2 from x recenters the wave so that f(0) = 0.
        float oscillateFactor = 0.5f * (1 + Mathf.Sin(speed * (Time.time - startTime) - (Mathf.PI/2)));
        transform.position = Vector2.Lerp(startPos, startPos + distance, oscillateFactor);
    }
}
