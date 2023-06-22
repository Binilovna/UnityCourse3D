using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadSide : MonoBehaviour
{
    private EventsController _eventsController;

    private void Awake()
    {
        _eventsController = GameObject.Find("EventsController").GetComponent<EventsController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _eventsController.OnPlayerDeath.Invoke();
        }
    }
}
