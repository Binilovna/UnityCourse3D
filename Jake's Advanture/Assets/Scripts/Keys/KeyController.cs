using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private Key key;
    private AudioSource _collectSource;

    [SerializeField] private GameObject eventsController;
    private EventsController _controller;
    void Start()
    {
        _collectSource = GameObject.Find("Collect").GetComponent<AudioSource>();
        key = gameObject.GetComponent<Key>();

        _controller = eventsController.GetComponent<EventsController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (key.keyType == Key.KeyType.Common)
            {
                PlayerPrefs.SetInt("current_commonKeysCount_prefs", PlayerPrefs.GetInt("current_commonKeysCount_prefs", 0) + 1);
                PlayerPrefs.SetInt("commonKeysCount_prefs", PlayerPrefs.GetInt("commonKeysCount_prefs", 0) + 1);
                
                _controller.UpdateKeyInfo.Invoke();
            }
            else if (key.keyType == Key.KeyType.Main)
            {
                PlayerPrefs.SetInt("current_mainKeysCount_prefs", PlayerPrefs.GetInt("current_mainKeysCount_prefs", 0) + 1);
                PlayerPrefs.SetInt("mainKeysCount_prefs", PlayerPrefs.GetInt("mainKeysCount_prefs", 0) + 1);
            }

            key.currentBorder.GetComponent<BoxCollider2D>().isTrigger = true;
            
            _collectSource.Play();
            
            
            gameObject.SetActive(false);
        }
    }
}
