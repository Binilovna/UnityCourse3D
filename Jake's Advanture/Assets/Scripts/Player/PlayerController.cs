using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private int _velocity;
    
    private bool _isRight;
    private bool _isLeft;
    
    private bool _isJump;
    private bool _isGrounded;
    
    private int _extraJumps;
    public int extraJumpsValue;


    private float _jumpForce;
    private void Start()
    {
        _jumpForce = gameObject.GetComponent<PlayerManager>().jumpForce;
    }

    void Update()
    {
        _isRight = false;
        _isLeft = false;
        if (Input.GetKey(KeyCode.A))
        {
            _isLeft = true;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            _isRight = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isRight == true)
        {
            Move(Vector2.right);
        }
        else if(_isLeft == true)
        {
            Move(Vector2.left);
        }

        if (_isJump == true)
        {
            _isJump = false;
            ResetExtraJumps();
            if (_isGrounded == true || _extraJumps > 0)
            {
                Jump();
                _isGrounded = false;
                _extraJumps--;
            }
        }
    }

    private void Move(Vector2 direction)
    {
        _rigidbody2D.AddForce(direction * _velocity);
    }

    private void Jump()
    {
        _rigidbody2D.velocity = Vector2.up * _jumpForce;
    }

    private void ResetExtraJumps()
    {
        if (_isGrounded)
        {
            _extraJumps = extraJumpsValue;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }
}
