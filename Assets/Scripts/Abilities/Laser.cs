using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Ability
{
    [SerializeField] float warmupDuration = 2;
    [SerializeField] GameObject laserPrefab = null;

    GameObject laserBeam;
    ParticleSystem warmupParticles;
    Camera mainCamera;
    Buff castDebuff;
    Transform targetTransform;
    void Start()
    {
        warmupParticles = GetComponent<ParticleSystem>();
        mainCamera = Camera.main;
        castDebuff = GetComponent<Buff>();
    }
    protected override void Update()
    {
        base.Update();
        if(laserBeam != null)
        {
            AimLaser();
        }
    }
    void AimLaser()
    {
        // Point laser to the mouse
        Vector2 targetPos = targetTransform.position;

        var pivotPos = transform.position;

        targetPos.x -= pivotPos.x;
        targetPos.y -= pivotPos.y;

        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        laserBeam.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    public override void CastAbility(Transform target)
    {
        targetTransform = target;
        warmupParticles.Play();
        if (castDebuff) { castDebuff.ApplyBuff(); }

        StartCoroutine(DelayedCast());
    }
    IEnumerator DelayedCast()
    {
        // Instantiate and aim laser after delay. After the remaining cast time, remove all effects and start cd.
        yield return new WaitForSeconds(warmupDuration);

        laserBeam = Instantiate(laserPrefab, transform.position, Quaternion.identity, transform);
        AimLaser();

        yield return new WaitForSeconds(castTime - warmupDuration);

        Destroy(laserBeam);
        warmupParticles.Stop();
        if (castDebuff) { castDebuff.RemoveBuff(); }
        StartCooldown();
    }
}
