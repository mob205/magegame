using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    [SerializeField] protected float castTime;
    protected bool activeCooldown;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public virtual void CastSpell()
    {
        Debug.Log("Spell cast not implemented.");
    }
    protected IEnumerator Cooldown()
    {
        activeCooldown = true;
        yield return new WaitForSeconds(cooldown);
        activeCooldown = false;
    }
}
