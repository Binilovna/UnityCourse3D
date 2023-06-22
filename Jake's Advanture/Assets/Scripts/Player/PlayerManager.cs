using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float jumpForce = 22f;
    public int healthPoints = 3;
    public bool isProtected;
    public int commonKeysCount;
    public int mainKeysCount;
    
    private void Awake()
    {
        commonKeysCount = PlayerPrefs.GetInt("commonKeysCount_prefs", 0);
        mainKeysCount = PlayerPrefs.GetInt("mainKeysCount_prefs", 0);
    }

    public void SaveProgress(int commonKeysCount, int mainKeysCount)
    {
        PlayerPrefs.SetInt("commonKeysCount_prefs", commonKeysCount);
        PlayerPrefs.SetInt("mainKeysCount_prefs", mainKeysCount);
    }

}
