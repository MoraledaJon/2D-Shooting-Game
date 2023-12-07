using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public EnemyType enemyType;
    
     public enum EnemyType
    {
        Straight,
        DoubleSpeed,
        ZigZag
    };


    void Update()
    {
        switch(enemyType)
        {
            case EnemyType.Straight:
                MovementStright.Instance.moveStraight(transform, false);
                break;
            case EnemyType.DoubleSpeed:
                MovementStright.Instance.moveStraight(transform, true);
                break;
            case EnemyType.ZigZag:
                ZigzagMovement.Instance.StartZigzagMovement(transform);
                break;

        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
