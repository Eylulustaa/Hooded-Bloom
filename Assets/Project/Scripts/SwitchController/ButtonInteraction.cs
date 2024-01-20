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

    void Start()
    {
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
            CharOnButton = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
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
                MovePlatforms(targetPositions);
            }
            else
            {
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
}