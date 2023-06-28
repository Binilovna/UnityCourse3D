using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBorder : MonoBehaviour
{
    [SerializeField] private string sphereTagName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(sphereTagName))
        {    
            Level1Controller.OnLevelComplite.Invoke();
        }
    }
}