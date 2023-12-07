using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStright : MonoBehaviour
{
    [SerializeField]
    float _moveSpeed = 10f;

    public static MovementStright Instance;

    private void Awake()
    {
        Instance = this;
    }


    public void  moveStraight(Transform t, bool doubleSpeed) 
    {
        if (doubleSpeed)
        {
            t.position = new Vector2(t.position.x + ((-_moveSpeed * 2) * Time.deltaTime), t.position.y);
        }
        else
        {
            t.position = new Vector2(t.position.x + (-_moveSpeed * Time.deltaTime), t.position.y);
        }
    }

}
