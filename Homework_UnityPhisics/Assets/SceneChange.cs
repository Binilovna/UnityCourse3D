using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(_OnLevelContinue);
    }
    private void _OnLevelContinue()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
