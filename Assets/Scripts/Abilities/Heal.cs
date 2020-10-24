using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Ability
{
    [SerializeField] int healAmount = 25;

    Health health;
    ParticleSystem particles;

    void Start()
    {
        health = GetComponentInParent<Health>();
        particles = GetComponent<ParticleSystem>();
    }

    public override void CastAbility(Transform target)
    {
        health.Heal(healAmount);
        particles.Play();
        StartCooldown();
    }
}
