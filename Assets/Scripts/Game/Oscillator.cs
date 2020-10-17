using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector2 distance = new Vector2(0, 0);
    [SerializeField] float speed = 1;
    Vector2 startPos;
    float startTime;
    private void Start()
    {
        startPos = transform.position;
        startTime = Time.time;
    }
    private void OnEnable()
    {
        transform.position = startPos;
        startTime = Time.time;
    }
    private void Update()
    {
        float oscillateFactor = 0.5f * (1 + Mathf.Sin(speed * (Time.time - startTime)));
        transform.position = Vector2.Lerp(startPos, startPos + distance, oscillateFactor);
    }
}
