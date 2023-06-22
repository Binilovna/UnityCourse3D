using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneScript : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(LoadOnClick);
    }

    private void LoadOnClick()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
