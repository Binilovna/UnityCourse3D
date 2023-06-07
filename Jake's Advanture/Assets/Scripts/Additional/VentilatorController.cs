using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentilatorController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float pushForce;
    private bool _isPush;
    private Vector2 _vector2;

    private Rigidbody2D _playerRigidbody2D;
    private void Start()
    {
        _playerRigidbody2D = player.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_isPush)
        {
            
            if (_isRightCheck())
            {
                _vector2 = Vector2.right;
            }
            else
            {
                _vector2 = Vector2.left;
            }
            
            _playerRigidbody2D.AddForce(_vector2 * pushForce);
        }
    }

    private bool _isRightCheck()
    {
        if (gameObject.transform.rotation.z == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    } 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isPush = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isPush = false;
        };
    }
}
