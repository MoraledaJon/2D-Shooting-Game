using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed;
    public float smoothing = 0.1f;

    public bool canMove = true;

    Camera mainCamera;

    [SerializeField]
    private ParticleSystem dieEffect;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if(canMove)
        {
            Vector2 targetVelocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
            body.velocity = Vector2.Lerp(body.velocity, targetVelocity, smoothing);

            // Calculate camera boundaries based on viewport coordinates
            float minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
            float maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
            float minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
            float maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

            // Clamp the player's position within the camera limits
            float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            ParticleSystem effect = Instantiate(dieEffect, transform.position, Quaternion.identity);
            effect.Play();
            ScoreManager.Instance.GameOver();
            SpawnManager.Instance.Spawn(false);
        }
    }
}
