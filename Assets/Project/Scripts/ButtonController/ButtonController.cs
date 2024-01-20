using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject[] platformsToToggle; // Platformlarý tutmak için dizi

    private bool isPlayerOnButton = false; // Karakter butonun üzerinde mi kontrol etmek için

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnButton = true; // Karakter butonun üzerine geldiðinde iþaretle
            TogglePlatformsVisibility(true); // Yarý görünür platformlarý tamamen görünür yap
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnButton = false; // Karakter butondan ayrýldýðýnda iþaretle
            TogglePlatformsVisibility(false); // Yarý görünür platformlarý tekrar yarý görünür yap
        }
    }

    private void TogglePlatformsVisibility(bool visible)
    {
        foreach (GameObject platform in platformsToToggle)
        {
            platform.SetActive(visible); // Platformlarýn görünürlüðünü ayarla
        }
    }
}
