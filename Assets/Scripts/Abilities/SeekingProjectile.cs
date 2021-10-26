using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingProjectile : Projectile
{
    [SerializeField] float rotationSpeed;
    [SerializeField] float seekRange = 50;

    private GameObject _target;
    private float _speed;
    private Rigidbody2D _rb;

    private void Start()
    {
        var targetsInRange = Physics2D.OverlapCircleAll(transform.position, seekRange);
        float leastDistance = Mathf.Infinity;
        foreach (var target in targetsInRange)
        {
            var squaredDist = (target.gameObject.transform.position - transform.position).sqrMagnitude;
            if (squaredDist < leastDistance && target.CompareTag("Enemy")) // use serialized layermask for editor control?
            {
                _target = target.gameObject;
                leastDistance = squaredDist;
            }
        }
        _rb = GetComponent<Rigidbody2D>();
        _speed = _rb.velocity.magnitude;
    }
    private void FixedUpdate()
    {
        var currentAngle = transform.rotation.eulerAngles.z;
        var targetAngle = Utility.GetFacingAngle(transform.position, _target.transform.position).eulerAngles.z;
        var angleDifference = targetAngle - currentAngle;
        if (angleDifference > 180)
        {
            angleDifference -= 360;
        }
        else if (angleDifference < -180)
        {
            angleDifference += 360;
        }
        transform.Rotate(new Vector3(0, 0, angleDifference * Time.fixedDeltaTime * rotationSpeed));
        _rb.velocity = transform.right * _speed;
        

        if(transform.rotation.eulerAngles.z > targetAngle)
        {

        }
    }

}
