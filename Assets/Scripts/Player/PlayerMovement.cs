using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMove {

    public float movementSpeed = 7;
    public float MoveSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }
    public bool CanMove { get; set; } = true;
    [Header("Jump")]
    [SerializeField] float jumpForce = 5;
    [SerializeField] Transform origin;
    [SerializeField] float castHeight = 0.1f;
    [SerializeField] float castSizeOffset = 0.1f;

    Rigidbody2D _rb;
    Animator _anim;
    LayerMask groundLayer;
    BoxCollider2D _physicsCollider;

    void Start ()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        groundLayer = LayerMask.GetMask("Ground");
        _physicsCollider = GetComponents<BoxCollider2D>().First(a => !a.isTrigger);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (!CanMove)
        {
            _rb.velocity = Vector2.zero;
            return; 
        }
        ProcessMovement();
        if (Input.GetAxisRaw("Jump") == 1)
        {
            Jump();
        }
    }
    public bool CheckGrounded()
    {
        // Casts a box from the bottom of the player. Slightly thinner than player to prevent walls triggering the boxcast.
        return Physics2D.BoxCast(origin.position, new Vector2(_physicsCollider.size.x - castSizeOffset, castHeight), 0, Vector2.down, 0, groundLayer);
    }

    private void Jump()
    {
        if(CheckGrounded())
        {
            _rb.velocity = Vector2.up * jumpForce;
        }
    }
    private void ProcessMovement()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized;

        _rb.velocity = new Vector2(movement.x * movementSpeed, _rb.velocity.y);
        
        if (horizontal != 0)
        {
            _anim.SetFloat("Movement", horizontal);
        }
    }
}
