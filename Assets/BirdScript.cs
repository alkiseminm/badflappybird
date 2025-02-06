using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 12f;       // Force applied for the jump
    public float gravityScale = 1f;     // Gravity scale for the Rigidbody2D

    private Rigidbody2D rb;
    private bool isJumping = true;      // Tracks whether the player is in the air (or wants to jump)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;  // Set custom gravity if needed
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Check for jump input (space bar) and make the player jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) && isJumping)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply an upward force to the Rigidbody2D
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // Reset vertical velocity to 0 before applying jump
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // Stop the player when colliding with another collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Stop the player's movement by setting their velocity to zero
        rb.linearVelocity = Vector2.zero; // Set both x and y velocity to 0 to stop movement

        // Optionally, stop jumping after collision (disable input)
        //isJumping = false;

        // Optionally: Log to see the collision detected
        Debug.Log("Collision!");
    }

    // Optionally, if you want to allow the character to jump again after colliding, you can reset `isJumping`:
    void OnCollisionExit2D(Collision2D collision)
    {
        // Allow jumping again when leaving the collision
        isJumping = true;
    }
}
