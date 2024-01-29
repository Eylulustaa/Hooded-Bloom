using UnityEngine;

public class ArrowPointer : MonoBehaviour
{
    public Transform exitPoint; // Set this in the Inspector to be the exit's transform
    public Transform player;   // Reference to the player's transform

    void Update()
    {
        if (exitPoint != null && player != null)
        {
            // Calculate the direction from the arrow to the exit
            Vector3 direction = exitPoint.position - transform.position;
            direction.Normalize();

            // Calculate the angle in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rotate the arrow towards the exit
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Update the arrow's position to be above the player
            transform.position = new Vector3(player.position.x, player.position.y + 0.7f, player.position.z);
        }
    }
}
