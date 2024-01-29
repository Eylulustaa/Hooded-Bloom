using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int totalItems = 3;
    private int collectedItems = 0;

    public TextMeshProUGUI collectedText;
    [SerializeField] GameObject exitDoor, pointer;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void CollectItem()
    {
        collectedItems++;
        UpdateCollectedText();

        if (collectedItems == totalItems)
        {
            collectedText.color = Color.red;
            OpenExitDoor();
        }
    }

    private void UpdateCollectedText()
    {
        if (collectedText != null)
            collectedText.text = collectedItems + "/" + totalItems;
    }

    private void OpenExitDoor()
    {
        if (exitDoor != null)
            exitDoor.SetActive(true);
            pointer.SetActive(true);
    }
}
