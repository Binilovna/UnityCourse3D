using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLockBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject GameCompletePanel;
    [SerializeField] private GameObject noticeUI;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            noticeUI.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Here");
                GameCompletePanel.SetActive(true);
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            noticeUI.SetActive(false);
        }
    }
}
