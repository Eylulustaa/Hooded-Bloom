using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject[] platformsToToggle; // Platformlar� tutmak i�in dizi

    private bool isPlayerOnButton = false; // Karakter butonun �zerinde mi kontrol etmek i�in

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnButton = true; // Karakter butonun �zerine geldi�inde i�aretle
            TogglePlatformsVisibility(true); // Yar� g�r�n�r platformlar� tamamen g�r�n�r yap
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnButton = false; // Karakter butondan ayr�ld���nda i�aretle
            TogglePlatformsVisibility(false); // Yar� g�r�n�r platformlar� tekrar yar� g�r�n�r yap
        }
    }

    private void TogglePlatformsVisibility(bool visible)
    {
        foreach (GameObject platform in platformsToToggle)
        {
            platform.SetActive(visible); // Platformlar�n g�r�n�rl���n� ayarla
        }
    }
}
