using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Level1Controller : MonoBehaviour
{
    public static Action OnLevelComplite;
    private List<Transform> levelGameObjects = new List<Transform>();

    [SerializeField] private GameObject _mainBorder;
    [SerializeField] private GameObject _continueButton; 

    private void Awake()
    {
        OnLevelComplite += _OnLevelComplite;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_mainBorder.TryGetComponent<FixedJoint>(out FixedJoint joint))
            {
                //joint.breakForce = 0.01f;
                Destroy(joint);
            }
        }
    }

    public void _OnLevelComplite()
    {
        levelGameObjects = gameObject.GetComponentsInChildren<Transform>().ToList();
        foreach (Transform obj in levelGameObjects)
        {
            if (obj.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.isKinematic = false;
            }
        }
        
        _continueButton.SetActive(true);
    }
}
