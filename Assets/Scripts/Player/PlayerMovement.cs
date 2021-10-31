using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMove {

    [SerializeField] public float movementSpeed = 7;
    public float MoveSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }
    public bool CanMove { get; set; } = true;
    [SerializeField] public float jumpForce = 5;

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
        if (!CanMove)
        {
            _rb.velocity = Vector2.zero;
            return; 
        }
        ProcessMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        //if(Input.GetAxisRaw("Jump") == 1)
        //{
        //    Jump();
        //}
    }
    public bool CheckGrounded()
    {
        //return Physics2D.Raycast(transform.position, Vector2.down, .6f, groundLayer);
        return Physics2D.BoxCast(transform.position, new Vector2(0.5f,1), 0, Vector2.down, .6f, groundLayer);
        
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
