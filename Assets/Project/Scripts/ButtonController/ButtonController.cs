using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject[] platformsToToggle; 
    public float delayBeforeInvisible = 3f; 
    public float delayBeforeVisible = 0f;

    public TextMesh countdownText; 

    private bool isPlayerOnButton = false; 
    private bool boxIn = false;

    public Sprite normalSprite;
    public Sprite interactedSprite;
    private SpriteRenderer spriteRenderer;

    public AudioClip buttonSound;
    private AudioSource audioSource;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        if (countdownText != null)
        {
            countdownText.text = delayBeforeVisible.ToString("F1"); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(!boxIn)
            {
                spriteRenderer.sprite = interactedSprite;
                PlaySound(buttonSound);
                isPlayerOnButton = true;
                StartCoroutine(TogglePlatformsAfterDelay(true, delayBeforeVisible)); 
            }
        }

        if (other.CompareTag("Box"))
        {
            spriteRenderer.sprite = interactedSprite;
            PlaySound(buttonSound);
            isPlayerOnButton = true;
            StartCoroutine(TogglePlatformsAfterDelay(true, delayBeforeVisible));
            boxIn = true;
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(!boxIn)
            {
                isPlayerOnButton = false; 
                StartCoroutine(TogglePlatformsAfterDelay(false, delayBeforeInvisible));
                spriteRenderer.sprite = normalSprite;
                PlaySound(buttonSound);
            }
        }

        if (other.CompareTag("Box"))
        {
            isPlayerOnButton = false; 
            StartCoroutine(TogglePlatformsAfterDelay(false, delayBeforeInvisible));
            spriteRenderer.sprite = normalSprite;
            PlaySound(buttonSound);
            boxIn = false;
        }

    }

    private System.Collections.IEnumerator TogglePlatformsAfterDelay(bool visible, float delay)
    {
        float countdown = delay;

        if (countdownText != null)
        {
            while (countdown > 0f)
            {
                countdownText.text = countdown.ToString("F1"); 
                yield return new WaitForSeconds(0.1f); 
                countdown -= 0.1f;
            }

            countdownText.text = "3.0";
        }
        TogglePlatformsVisibility(visible); 
    }

    private void TogglePlatformsVisibility(bool visible)
    {
        foreach (GameObject platform in platformsToToggle)
        {
            platform.SetActive(visible); 
        }
    }

    private void PlaySound(AudioClip soundClip)
    {
       audioSource.PlayOneShot(soundClip);
    }
}
