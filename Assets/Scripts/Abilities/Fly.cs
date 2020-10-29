using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Ability
{
    [SerializeField] float flyStrength = 20f;
    [SerializeField] float slowfallDrag = 5f;
    [SerializeField] float slowfallDelay = 0.5f;

    Rigidbody2D targetRB;
    bool isSlowfall;
    void Start()
    {
        targetRB = GetComponentInParent<Rigidbody2D>();
    }
    public override void CastAbility(Transform target)
    {
        targetRB.velocity = Vector2.up * flyStrength;
        StartCoroutine(StartSlowfall());
        StartCooldown();
    }
    IEnumerator StartSlowfall()
    {
        yield return new WaitForSeconds(slowfallDelay);
        targetRB.drag = slowfallDrag;
        isSlowfall = true;
    }
    protected override void Update()
    {
        base.Update();
        CheckSlowfall();
    }
    void CheckSlowfall()
    {
        if (isSlowfall)
        {
            if (Physics2D.BoxCast(transform.position, new Vector2(0.5f, 1), 0, Vector2.down, .6f, LayerMask.GetMask("Ground")))
            {
                isSlowfall = false;
                targetRB.drag = 0;
            }
        }
    }
}
