using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultStartBehaviour : MonoBehaviour
{
    private Ray _ray;
    private RaycastHit _hit;

    [SerializeField] private GameObject _catapultPlane;
    [SerializeField] private string catapultTag = "Catapult";
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit))
            {
                Debug.Log("Ray distination is defined Level Complite");
                if (_hit.collider.gameObject.CompareTag(catapultTag))
                {
                    Debug.Log("Check Tag Level Complite");
                    
                    if (_catapultPlane.TryGetComponent<Rigidbody>(out Rigidbody _rigit))
                    {
                        Debug.Log("Set kinematic value Level Complite");
                        _rigit.isKinematic = false;
                    }
                }

                
            }
        }
    }
}
