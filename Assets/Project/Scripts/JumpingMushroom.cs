using UnityEngine;

public class JumpingMushroom: MonoBehaviour
{
    public float jumpForce = 10f;

    public AudioClip mushroomSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                PlaySound(mushroomSound);
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            }
        }
    }

    private void PlaySound(AudioClip soundClip)
    {
        audioSource.PlayOneShot(soundClip);
    }
}