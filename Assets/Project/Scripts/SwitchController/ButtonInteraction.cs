using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public GameObject[] platforms;
    public Vector3[] targetPositions;
    public float movementSpeed = 5f;

    private Vector3[] originalPositions;
    private bool platformsMoved = false;
    private bool isInteracting = false; // Etkileþimin devam ettiðini belirten deðiþken
    private bool platformover = false;
    private bool CharOnButton = false;
    private float startTime;
    private float journeyLength;

    public Sprite normalSprite;
    public Sprite interactedSprite; 
    private SpriteRenderer spriteRenderer;
    public GameObject E;

    public AudioClip switcherSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        originalPositions = new Vector3[platforms.Length];
        for (int i = 0; i < platforms.Length; i++)
        {
            originalPositions[i] = platforms[i].transform.position;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CharOnButton)
        {
            platformover = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            E.SetActive(true);
            CharOnButton = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            E.SetActive(false);
            CharOnButton = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Trigger Entered");
        if (other.CompareTag("Player") && platformover && !isInteracting) // Eðer etkileþime giren nesne "Player" etiketine sahipse ve etkileþim devam etmiyorsa
        {
            Debug.Log("Player Entered the Trigger");
            isInteracting = true; // Etkileþim baþladý

            if (!platformsMoved)
            {
                PlaySound(switcherSound);
                spriteRenderer.sprite = interactedSprite;
                MovePlatforms(targetPositions);
            }
            else
            {
                PlaySound(switcherSound);
                spriteRenderer.sprite = normalSprite;
                MovePlatforms(originalPositions);
            }

            
        }
    }

    void MovePlatforms(Vector3[] destination)
    {
        startTime = Time.time;

        for (int i = 0; i < platforms.Length; i++)
        {
            StartCoroutine(MovePlatform(platforms[i].transform, destination[i]));
        }

        platformsMoved = !platformsMoved;
    }

    System.Collections.IEnumerator MovePlatform(Transform platform, Vector3 target)
    {
        float elapsedTime = 0f;
        Vector3 startingPos = platform.position;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * movementSpeed;
            platform.position = Vector3.Lerp(startingPos, target, elapsedTime);
            yield return null;
        }

        platform.position = target;

        isInteracting = false; // Etkileþim tamamlandý, bir sonraki etkileþim için izin ver
        platformover = false;
    }

    private void PlaySound(AudioClip soundClip)
    {
        audioSource.PlayOneShot(soundClip);
    }
}