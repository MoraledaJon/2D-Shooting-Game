using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigzagMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float verticalRange = 2f;

    private bool isMovingUp = true;

    public static ZigzagMovement Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void StartZigzagMovement(Transform t)
    {
        StartCoroutine(ZigzagCoroutine(t));
    }

    private IEnumerator ZigzagCoroutine(Transform t)
    {
        while (true)
        {
            // Calculate vertical movement
            float verticalMovement = isMovingUp ? verticalRange : -verticalRange;

            // Calculate movement vector
            Vector2 movement = new Vector2(-moveSpeed, verticalMovement);

            // Update position
            t.Translate(movement * Time.deltaTime);

            // Check if the enemy has reached the top or bottom limit
            if (Mathf.Abs(t.position.y) >= verticalRange)
            {
                // Toggle the direction
                isMovingUp = !isMovingUp;
            }

            yield return null;
        }
    }
}