using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectsBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Plane"))
        {
            Destroy(gameObject);
        }
    }
}
