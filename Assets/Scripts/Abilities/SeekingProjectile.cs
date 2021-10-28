using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingProjectile : Projectile
{
    [SerializeField] float rotationSpeed;
    [SerializeField] float seekRange = 50;
    [SerializeField] LayerMask targetLayers;

    private GameObject _target;
    private float _speed;
    private Rigidbody2D _rb;

    // To detach particles
    private ParticleSystem _particles;

    private void Start()
    {
        FindTarget();
        _rb = GetComponent<Rigidbody2D>();
        _speed = _rb.velocity.magnitude;
        _particles = GetComponentInChildren<ParticleSystem>();
    }
    private void FindTarget()
    {
        _target = null;
        var targetsInRange = Physics2D.OverlapCircleAll(caster.transform.position, seekRange);
        float leastDistance = Mathf.Infinity;
        foreach (var target in targetsInRange)
        {
            var squaredDist = (target.gameObject.transform.position - transform.position).sqrMagnitude;
            //if (squaredDist < leastDistance && (targetLayers.value >> target.gameObject.layer) == 1) // Checks if potential target's layer is in the set layermask
            if (squaredDist < leastDistance && (targetLayers.value & (1 << (target.gameObject.layer))) > 0) 
            {
                _target = target.gameObject;
                leastDistance = squaredDist;
            }
        }
    }
    private void FixedUpdate()
    {
        if (_target == null || _target.activeSelf == false)
        {
            FindTarget();
        } 
        else
        {
            // Finds the shortest direction to rotate to face the target, then rotates projectile in that direction by a fixed amount (rotationSpeed)
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
            var angleDirection = angleDifference / Mathf.Abs(angleDifference);
            transform.Rotate(new Vector3(0, 0, angleDirection * Time.fixedDeltaTime * rotationSpeed));
            _rb.velocity = transform.right * _speed;
        }
    }
    protected override void OnSuccessfulHit(Collider2D collision, Health hitHealth)
    {
        base.OnSuccessfulHit(collision, hitHealth);
        _particles.transform.parent = null;
        _particles.Stop();
        Destroy(_particles.gameObject, _particles.main.startLifetime.constant);
    }
}
