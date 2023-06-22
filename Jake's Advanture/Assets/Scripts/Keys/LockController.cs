using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    private Lock _lock;
    [SerializeField] private GameObject noticeUI;
    [SerializeField] private EventsController _eventsController;

    private bool _isOpening;

    private void Start()
    {
        _lock = gameObject.GetComponentInParent<Lock>();
    }
    private void Update()
    {
        if (_isOpening)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _lock.Open(_lock.keysNeed);
                _eventsController.UpdateKeyInfo.Invoke();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        _isOpening = true;
        noticeUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isOpening = false;
        noticeUI.SetActive(false);
    }
}
