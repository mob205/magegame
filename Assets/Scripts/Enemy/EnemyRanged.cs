using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour, ICaster
{
    [SerializeField] float castDelay = 1f;
    [SerializeField] float aggroRange = 1f;
    [SerializeField] float[] castChances = new float[5];

    Ability[] abilities = new Ability[5];
    private bool isCasting;
    float remainingCT;
    GameObject player;
    public bool CanCast { get; set; } = true;
    public float DamageModifier { get; set; } = 1;

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
        GetRandomIndex();
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
            var random = GetRandomIndex();
            abilities[random].CastAbility(player.transform);
            StartCastTime(abilities[random].CastTime + castDelay);
        }
    }
    private int GetRandomIndex()
    {
        float random = Random.Range(0, 101);
        for(int i = 0; i < castChances.Length; i++)
        {
            random -= castChances[i];
            if(random <= 0)
            {
                return i;
            }
        }
        return 0;
    }
    private void StartCastTime(float castTime)
    {
        isCasting = true;
        remainingCT = castTime;
    }
}
