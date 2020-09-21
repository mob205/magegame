using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Ability
{
    [SerializeField] float warmupDuration = 2;
    [SerializeField] float damagePerTick = 10;
    [SerializeField] int ticksPerSecond = 1;
    [SerializeField] LaserBeam laserPrefab = null;

    LaserBeam laserBeam;
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
        laserBeam.transform.rotation = Utility.GetFacingAngle(transform.position, targetTransform.position);
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
        laserBeam.damagePerTick = damagePerTick;
        laserBeam.ticksPerSecond = ticksPerSecond;
        laserBeam.caster = gameObject;

        AimLaser();

        yield return new WaitForSeconds(castTime - warmupDuration);

        Destroy(laserBeam.gameObject);
        warmupParticles.Stop();
        if (castDebuff) { castDebuff.RemoveBuff(); }
        StartCooldown();
    }
}
