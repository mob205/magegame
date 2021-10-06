using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] float followRadius = 5;
    [SerializeField] float moveSpeed = 3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }
    void UpdatePosition()
    {
        var posX = followRadius * Mathf.Cos(Time.time * moveSpeed);
        var posY = followRadius * Mathf.Sin(Time.time * moveSpeed);
        transform.localPosition = new Vector2(posX, posY);
        Debug.Log("(" + posX + ", " + posY + ")");
    }
}
