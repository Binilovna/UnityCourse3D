using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKickedSide : MonoBehaviour
{
    public GameObject enemy;
    private Collider2D[] _enemyColliders;

    private void Start()
    {
        _enemyColliders = enemy.GetComponentsInChildren<Collider2D>();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TimeWait());
            foreach (Collider2D collider2D in _enemyColliders)
            {
                Destroy(collider2D);
            }
        }
    }

    IEnumerator TimeWait()
    {
        yield return new WaitForSecondsRealtime(2f);
        
        Destroy(enemy);
    }
}
