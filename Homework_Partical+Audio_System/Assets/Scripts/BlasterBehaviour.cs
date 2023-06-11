using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject fireParticles;
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            fireParticles.SetActive(true);
        }
        else
        {
            fireParticles.SetActive(false);
        }
    }
    
}
