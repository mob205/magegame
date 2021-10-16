using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector2 distance = new Vector2(0, 0);
    [SerializeField] float speed = 1;
    [SerializeField] bool startOnContact;

    Vector2 startPos;
    float startTime;
    bool hasStarted;

    //Dictionary<GameObject, Transform> originalParents = new Dictionary<GameObject, Transform>();
    private void OnEnable()
    {
        if (!startOnContact)
        {
            StartMovement();
        }
    }
    private void StartMovement()
    {
        hasStarted = true;
        if (startPos == new Vector2(0, 0))
        {
            startPos = transform.position;
        }
        transform.position = startPos;
        startTime = Time.time;
    }
    private void FixedUpdate()
    {
        // Oscillate factor calculated through a sine function of time.
        // f(x) = 0.5sin(x)+0.5 makes the range of f [0,1] so it is usable by the Lerp function.
        // Subtraction of pi / 2 from x recenters the wave so that f(0) = 0.
        if (hasStarted)
        {
            float oscillateFactor = 0.5f * (1 + Mathf.Sin(speed * (Time.time - startTime) - (Mathf.PI / 2)));
            transform.position = Vector2.Lerp(startPos, startPos + distance, oscillateFactor);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerAbilities.instance.gameObject)
        {
            if (!hasStarted)
            {
                StartMovement();
            }
            collision.gameObject.transform.parent = gameObject.transform;
            //originalParents.Add(collision.gameObject, collision.gameObject.transform.parent);
            //collision.gameObject.transform.parent = gameObject.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerAbilities.instance.gameObject)
        {
            collision.gameObject.transform.parent = null; 
        }
        //if (originalParents.ContainsKey(collision.gameObject))
        //{
        //    collision.gameObject.transform.parent = originalParents[collision.gameObject];
        //    originalParents.Remove(collision.gameObject);
        //}

    }
}
