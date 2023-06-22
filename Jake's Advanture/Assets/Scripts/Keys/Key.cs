using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public KeyType keyType;
    public GameObject currentBorder;
    public enum KeyType
    {
        Common,
        Main
    }
}
