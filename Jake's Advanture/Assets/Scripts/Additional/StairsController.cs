using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsController : MonoBehaviour
{
    [SerializeField] private int climbForce;
    [SerializeField] private GameObject player;
    private Rigidbody2D _rigidbody2D;
    
    private bool _isСlimb;
    private bool _isUp;
    private bool _isDown;
    void Start()
    {
        _rigidbody2D = player.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        _isDown = false;
        _isUp = false;
        if (_isСlimb)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("Stair Up");
                _isUp = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                Debug.Log("Stair Down");
                _isDown = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_isUp)
        {
            Climb(Vector2.up);
        }

        if (_isDown)
        {
            Climb(Vector2.down);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter to stair");
        _isСlimb = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _isСlimb = false;
    }

    private void Climb(Vector2 direction)
    {
        _rigidbody2D.velocity = direction * climbForce;
    }
}
