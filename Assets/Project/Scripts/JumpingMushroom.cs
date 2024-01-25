using UnityEngine;

public class JumpingMushroom: MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Trambolin üzerine çýkýnca zýplama kuvveti uygula
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            }
        }
    }
}