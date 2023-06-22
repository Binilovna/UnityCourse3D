using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    [SerializeField] private int targetLevelIndex;
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject transitionPanel;
    private Camera _camera;
    private List<Vector3> _cameraPositions;

    private Animator _transitionPanelAnimator;
    private bool _trasitionComplite;
    private void Start()
    {
        _transitionPanelAnimator = transitionPanel.GetComponent<Animator>();

        _camera = Camera.GetComponent<Camera>();
        _cameraPositions = _camera.cameraPositions;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            if (PlayerPrefs.GetInt("current_mainKeysCount_prefs", 0) == 1 )
            {
                Debug.Log("Transition to " + targetLevelIndex);
                PlayerPrefs.SetInt("currentLevelIndex", targetLevelIndex);
                
                float transitionTime = 5f;
                
                StartCoroutine(DoMove(transitionTime, _cameraPositions[targetLevelIndex]));
                
                KeysAndMonetUpdate();
                _trasitionComplite = true;
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_trasitionComplite)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            _trasitionComplite = false;

            transitionPanel.SetActive(true);
        }
    }

    private void KeysAndMonetUpdate()
    {
        PlayerPrefs.SetInt("current_mainKeysCount_prefs", 0);
        PlayerPrefs.SetInt("current_commonKeysCount_prefs", 0);
        PlayerPrefs.SetInt("current_monet", 0);
    }

    private IEnumerator DoMove(float time, Vector3 targetPosition)
    {
        Vector2 startPosition = Camera.transform.position;
        float startTime = Time.realtimeSinceStartup;
        float fraction = 0f;
        
        while (fraction < 1f)
        {
            fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / time); 
            Camera.transform.position =
                Vector3.Lerp(Camera.transform.position,_cameraPositions[targetLevelIndex], fraction);
            yield return null;
        }
    }
}
