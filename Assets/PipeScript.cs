using UnityEngine;

public class WallController : MonoBehaviour
{
    public float speed = 5f;              // Speed at which the walls move
    public float resetPositionX = 12f;   // Position to reset the wall to
    public float teleportThresholdX = -12f; // Position where the wall resets
    public float maxY = 2f;              // Maximum allowed y position
    public float minY = -2f;             // Minimum allowed y position

    private Vector3 initialPosition;     // To track the initial position of the wall

    void Start()
    {
        // Store the initial position of the wall
        initialPosition = transform.position;
    }

    void Update()
    {
        // Move the wall to the left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Check if the wall has gone past the threshold
        if (transform.position.x <= teleportThresholdX)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        // Generate a random offset for the y position
        float randomY = Random.Range(-2f, 2f);

        // Ensure the wall resets to the right with the randomized y position
        transform.position = new Vector3(resetPositionX, Mathf.Clamp(initialPosition.y + randomY, minY, maxY), transform.position.z);
    }
}
