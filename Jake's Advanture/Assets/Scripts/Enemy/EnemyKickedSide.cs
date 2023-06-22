using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyKickedSide : MonoBehaviour
{
    public GameObject player;
    public Enemy enemy;
    private List<Collider2D> _enemyColliders;
    private float _reboundForce;
    private Vector2 _reboundDirection;
    private Animator _animator;
    private void Start()
    {
        _animator = gameObject.GetComponentInParent<Animator>();
            
        _enemyColliders = enemy.gameObject.GetComponentsInChildren<Collider2D>().ToList();
        if (_enemyColliders == null) // для паука у которого коллайдер висит на нем а не в дочерних елементах
        {
            _enemyColliders.Add(enemy.gameObject.GetComponent<TilemapCollider2D>());
        }
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CheckEnemy();
            StartCoroutine(TimeWait());
            
            player.GetComponent<Rigidbody2D>().velocity +=
                _reboundDirection * _reboundForce;
            
            foreach (Collider2D collider2D in _enemyColliders)
            {
                Destroy(collider2D);
            }      
        }
    }

    private void CheckEnemy()
    {
        if (enemy.enemyType == Enemy.EnemyType.Turtle)
        {
            _reboundDirection = Vector2.up;
            _reboundForce = player.GetComponent<PlayerManager>().jumpForce / 3;
            
            _animator.Play("TurtleDeath");
        }
        else if(enemy.enemyType == Enemy.EnemyType.Crab)
        {
            _reboundDirection = new Vector2(-1f, 1f);
            _reboundForce = player.GetComponent<PlayerManager>().jumpForce / 1.5f;
        }
        else if(enemy.enemyType == Enemy.EnemyType.Dragonfly)
        {
            _reboundDirection = Vector2.down;
            _reboundForce = player.GetComponent<PlayerManager>().jumpForce * 2;
        }
        else if (enemy.enemyType == Enemy.EnemyType.Spider)
        {
            _reboundDirection = Vector2.zero;
        }
    }
    IEnumerator TimeWait()
    {
        yield return new WaitForSecondsRealtime(2f);
        
        Destroy(enemy.gameObject);
    }
}
