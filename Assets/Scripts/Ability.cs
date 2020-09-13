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
    [SerializeField] public Sprite icon;
    protected bool activeCooldown;
    public float remainingCD;
    

    void Start()
    {

    }

    protected void Update()
    {
        UpdateCooldown();
    }

    private void UpdateCooldown()
    {
        if (activeCooldown)
            remainingCD -= Time.deltaTime;
        if (remainingCD <= 0)
        {
            activeCooldown = false;
        }
    }

    public virtual void CastAbility()
    {
        Debug.Log("Spell cast not implemented.");
    }
    protected void StartCooldown()
    {
        activeCooldown = true;
        remainingCD = cooldown;
    }
}
