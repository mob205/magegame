using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonAlly : Ability
{
    [SerializeField] float allyDuration;
    [SerializeField] GameObject summonPrefab;

    private void Start()
    {

    }
    public override void CastAbility(Transform target)
    {
        var summon = Instantiate(summonPrefab, (Vector2)target.transform.position, target.transform.rotation);
        Destroy(summon, allyDuration);
        StartCooldown();
    }
}
