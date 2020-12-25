using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] float followRange = 20f;
    [SerializeField] float followDist = 1f;
    [SerializeField] float moveSpeed = 5f;

    Rigidbody2D rb;
    PlayerAbilities player;
    void Start()
    {
        player = PlayerAbilities.instance;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var dist = Vector2.Distance(transform.position, player.transform.position);
        if (dist <= followRange && (dist >= followDist))
        {
            var direction = (player.transform.position - transform.position).normalized;
            rb.velocity = (direction * moveSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
    }
}
