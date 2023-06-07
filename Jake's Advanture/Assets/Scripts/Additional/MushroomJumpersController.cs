using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class MushroomJumpersController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float jumpCof;
    
    private float _mushroomJumpForce;
    void Start()
    {
        _mushroomJumpForce = player.GetComponent<PlayerManager>().jumpForce * jumpCof;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody2D>().velocity =
                UnityEngine.Vector2.up * _mushroomJumpForce;
        }
    }
}
