using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public int keysNeed;

    public void Open(int keys)
    {
        if (PlayerPrefs.GetInt("commonKeysCount_prefs") > 0)
        {
            PlayerPrefs.SetInt("commonKeysCount_prefs", PlayerPrefs.GetInt("commonKeysCount_prefs") - 1);
            Destroy(gameObject);
        }
    }
    
}
