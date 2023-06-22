using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("currentLevel"))
        {
            PlayerPrefs.SetInt("currentLevel", 0);
        }
    }

    private void Update()
    {
        throw new NotImplementedException();
    }
}
