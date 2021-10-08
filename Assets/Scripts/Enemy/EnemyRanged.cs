using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour, ICaster
{
    [SerializeField] float castDelay = 1f;
    [SerializeField] float aggroRange = 1f;

    Ability[] abilities = new Ability[5];
    private bool isCasting;
    float remainingCT;
    GameObject player;
    public bool CanCast { get; set; } = true;

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
        var isAggro = Vector2.Distance(transform.position, player.transform.position) <= aggroRange;
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
