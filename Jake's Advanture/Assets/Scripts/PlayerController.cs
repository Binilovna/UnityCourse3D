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
    [SerializeField] private int _jumpForce;
    
    private bool isRight;
    private bool isLeft;
    
    private bool isJump;
    private bool isGrounded;
    
    private int _extraJumps;
    public int extraJumpsValue;
    
    
    void Update()
    {
        isRight = false;
        isLeft = false;
        if (Input.GetKey(KeyCode.A))
        {
            isLeft = true;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            isRight = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetExtraJumps();
            if (isGrounded == true || _extraJumps > 0)
            {
                Jump();
                isGrounded = false;
                _extraJumps--;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isRight == true)
        {
            Move(Vector2.right);
        }
        else if(isLeft == true)
        {
            Move(Vector2.left);
        }

        /*if (isJump == true)
        {
            if (isGrounded == true)
            {
                Jump();
                isGrounded = false;
                isJump = false;
            }
        }*/
    }

    private void Move(Vector2 direction)
    {
        _rigidbody2D.AddForce(direction * _velocity);
    }

    private void Jump()
    {
        Debug.Log("Jump");
        _rigidbody2D.velocity = Vector2.up *_jumpForce;
    }

    private void ResetExtraJumps()
    {
        if (isGrounded)
        {
            _extraJumps = extraJumpsValue;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground");
            isGrounded = true;
        }
    }
}
