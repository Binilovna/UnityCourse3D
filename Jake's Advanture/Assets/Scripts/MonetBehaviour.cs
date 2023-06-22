using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonetBehaviour : MonoBehaviour
{
    [SerializeField] private EventsController _eventsController;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("current_monet", PlayerPrefs.GetInt("current_monet", 0) + 1);
            PlayerPrefs.SetInt("monet", PlayerPrefs.GetInt("monet", 0) + 1);
            
            _eventsController.UpdateMonetInfo.Invoke();
            gameObject.SetActive(false);
        }
    }
}
