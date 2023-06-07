using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType enemyType;
    public enum EnemyType
    {
        Turtle,
        Crab,
        Dragonfly,
        Spider
    }

}
