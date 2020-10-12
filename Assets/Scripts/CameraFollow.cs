using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float smoothing = 0.1f;
    [SerializeField] BoxCollider2D viewBox = null;

    PlayerAbilities player;
    Camera cam;
    Vector2 minBounds, maxBounds;
    void Start()
    {
        player = PlayerAbilities.instance;
        cam = GetComponent<Camera>();
    }
    void FixedUpdate()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {
        
        var min = viewBox.bounds.min;
        var max = viewBox.bounds.max;
        var x = player.transform.position.x;
        var y = player.transform.position.y;

        // Ortho size (Distance from center to top) multiplied by resolution for dist from center to side of screen
        var cameraHalfX = cam.orthographicSize * ((float)Screen.width / Screen.height);

        // Ensures camera stays within view box bounds
        x = Mathf.Clamp(x, min.x + cameraHalfX, max.x - cameraHalfX);
        y = Mathf.Clamp(y, min.y + cam.orthographicSize, max.y = cam.orthographicSize);

        // Smoothly move camera to calculated position. Vector3 Lerp (vs 2) to preserve camera's z offset.
        transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, transform.position.z), smoothing);
    }
}
