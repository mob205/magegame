using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] float _movementSpeed = 7;
    [SerializeField] float _jumpForce = 5;

    Rigidbody2D _rb;
    Animator _anim;
    LayerMask groundLayer;

    void Start ()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        groundLayer = LayerMask.GetMask("Ground");
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private bool CheckGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, .6f, groundLayer);
    }

    private void Jump()
    {
        if(CheckGrounded())
        {
            _rb.velocity = Vector2.up * _jumpForce;
        }
    }
    private void ProcessMovement()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized;

        _rb.velocity = new Vector2(movement.x * _movementSpeed, _rb.velocity.y);
        
        if (horizontal != 0)
        {
            _anim.SetFloat("Movement", horizontal);
        }
    }
}
