using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAI : MonoBehaviour, ICaster
{
    [SerializeField] float castDelay = 1f;
    [SerializeField] float aggroRange = 1f;

    Ability[] abilities = new Ability[5];
    private bool isCasting;
    float remainingCT;
    GameObject target;
    public bool CanCast { get; set; } = true;
    public float DamageModifier { get; set; } = 1;

    void Awake()
    {
        abilities = GetComponentsInChildren<Ability>();
    }
    void Update()
    {
        target = FindTarget();
        UpdateCastTime();
        CastAbilities();
    }

    private GameObject FindTarget()
    {
        var targetsInRange = Physics2D.OverlapCircleAll(transform.position, aggroRange);
        GameObject closestTarget = null;
        float leastDistance = Mathf.Infinity;
        foreach(var target in targetsInRange)
        {
            var squaredDist = (target.gameObject.transform.position - transform.position).sqrMagnitude;
            if(squaredDist < leastDistance && target.CompareTag("Enemy")) // use serialized layermask for editor control?
            {
                closestTarget = target.gameObject;
                leastDistance = squaredDist;
            }
        }
        return closestTarget;
    }

    private void UpdateCastTime()
    {
        // Update the time until object can cast another ability.
        if (isCasting)
            remainingCT -= Time.deltaTime;
        if (remainingCT <= 0)
        {
            isCasting = false;
        }
    }
    private void CastAbilities()
    {
        if (!CanCast) { return; }
        if (target && !isCasting)
        {
            var random = Random.Range(0, abilities.Length);
            abilities[random].CastAbility(target.transform);
            StartCastTime(abilities[random].CastTime + castDelay);
        }
    }
    private void StartCastTime(float castTime)
    {
        isCasting = true;
        remainingCT = castTime;
    }
}
