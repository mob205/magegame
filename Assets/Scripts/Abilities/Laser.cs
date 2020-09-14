using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Ability
{
    [SerializeField] float warmupDuration;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] IEffect<ISlowable> warmupEffect;
    [SerializeField] float effectModifier;

    GameObject laserBeam;
    ParticleSystem warmupParticles;
    Camera mainCamera;
    ISlowable effectTarget;
    void Start()
    {
        warmupParticles = GetComponent<ParticleSystem>();
        mainCamera = Camera.main;
        effectTarget = GetComponentInParent<ISlowable>();
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
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        var pivotPos = transform.position;

        mousePos.x -= pivotPos.x;
        mousePos.y -= pivotPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        laserBeam.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    public override void CastAbility()
    {
        warmupParticles.Play();
        if(warmupEffect != null)
            warmupEffect.ApplyEffect(effectTarget, effectModifier);

        StartCoroutine(DelayedCast());
    }
    IEnumerator DelayedCast()
    {
        yield return new WaitForSeconds(warmupDuration);

        laserBeam = Instantiate(laserPrefab, transform.position, Quaternion.identity, transform);
        AimLaser();

        yield return new WaitForSeconds(castTime - warmupDuration);

        Destroy(laserBeam);
        warmupParticles.Stop();
        StartCooldown();
        if(warmupEffect != null)
            warmupEffect.ApplyEffect(effectTarget, 1/effectModifier);
    }
}
