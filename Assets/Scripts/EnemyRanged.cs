using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyRanged : MonoBehaviour
{
    [SerializeField] float castDelay = 1f;
    Ability[] abilities = new Ability[5];
    private bool isCasting;
    float remainingCT;
    GameObject player;
    bool isAggro;

    void Awake()
    {
        abilities = GetComponentsInChildren<Ability>();
        player = PlayerAbilities.instance.gameObject;
    }
    void Update()
    {
        UpdateCastTime();
        CastAbilities();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAggro = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAggro = false;
        }
    }
    private void UpdateCastTime()
    {
        if (isCasting)
            remainingCT -= Time.deltaTime;
        if (remainingCT <= 0)
        {
            isCasting = false;
        }
    }
    private void CastAbilities()
    {
        if (isAggro)
        {
            var random = Random.Range(0, abilities.Length - 1);
            abilities[random].CastAbility();
            StartCastTime(abilities[random].CastTime + castDelay);
        }
    }
    private void StartCastTime(float castTime)
    {
        isCasting = true;
        remainingCT = castTime;
    }
}
