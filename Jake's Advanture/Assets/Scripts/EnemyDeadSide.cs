using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadSide : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
