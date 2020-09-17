using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    public float Cooldown
    {
        get { return cooldown; }
    }
    [SerializeField] protected float castTime;
    public float CastTime
    {
        get { return castTime; }
    }
    [SerializeField] public Sprite icon;
    public bool activeCooldown;
    [HideInInspector] public float remainingCD;
    
    protected virtual void Update()
    {
        UpdateCooldown();
    }
    // Check for cooldowns in a way where progress can be monitored for timers
    private void UpdateCooldown()
    {
        if (activeCooldown)
            remainingCD -= Time.deltaTime;
        if (remainingCD <= 0)
        {
            activeCooldown = false;
        }
    }

    public virtual void CastAbility(Transform target)
    {
        Debug.Log("Spell cast not implemented.");
    }
    protected void StartCooldown()
    {
        activeCooldown = true;
        remainingCD = cooldown;
    }
}
