using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    [SerializeField] float castDelay = 1f;
    [SerializeField] float aggroRange = 10f;

    Ability[] abilities = new Ability[5];
    private bool isCasting;
    float remainingCT;
    GameObject player;
    bool isAggro;

    void Awake()
    {
        abilities = GetComponentsInChildren<Ability>();
    }
    private void Start()
    {
        player = PlayerAbilities.instance.gameObject;
    }
    void Update()
    {
        UpdateCastTime();
        CastAbilities();
        CheckAggro();
    }
    void CheckAggro()
    {
        if(Vector2.Distance(transform.position, player.transform.position) <= aggroRange)
        {
            isAggro = true;
        }
        else
        {
            isAggro = false;
        }
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
        if (isAggro && !isCasting)
        {
            var random = Random.Range(0, abilities.Length);
            abilities[random].CastAbility(player.transform);
            StartCastTime(abilities[random].CastTime + castDelay);
        }
    }
    private void StartCastTime(float castTime)
    {
        isCasting = true;
        remainingCT = castTime;
    }
}
