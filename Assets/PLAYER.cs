using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalSpeed = 5f; // speed of horizontal movement
    public float verticalSpeed = 3f;   // constant vertical velocity

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Get horizontal input (-1 for left, 1 for right)
        float moveX = Input.GetAxisRaw("Horizontal");

        // Set velocity: constant upward motion + horizontal control
        rb.velocity = new Vector2(moveX * horizontalSpeed, verticalSpeed);
    }
}
