using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject[] platformsToToggle; // Platformlar� tutmak i�in dizi
    public float delayBeforeInvisible = 3f; // G�r�nmez olmadan �nce beklenilecek s�re
    public float delayBeforeVisible = 0f; // G�r�n�r olmadan �nce beklenilecek s�re

    public TextMesh countdownText; // 3D TextMesh objesi

    private bool isPlayerOnButton = false; // Karakter butonun �zerinde mi kontrol etmek i�in
    private bool boxIn = false;

    private void Start()
    {
        // E�er kullan�lmak �zere bir TextMesh objesi atanm��sa, ba�lang��ta g�sterilecek s�reyi ayarla
        if (countdownText != null)
        {
            countdownText.text = delayBeforeVisible.ToString("F1"); // Ba�lang��ta g�sterilecek s�reyi ayarla
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(!boxIn)
            {
                isPlayerOnButton = true;
                StartCoroutine(TogglePlatformsAfterDelay(true, delayBeforeVisible)); 
            }
        }

        if (other.CompareTag("Box"))
        {
            isPlayerOnButton = true; // Karakter butonun �zerine geldi�inde i�aretle
            StartCoroutine(TogglePlatformsAfterDelay(true, delayBeforeVisible)); // Belirtilen s�re sonra platformlar� g�r�n�r yap
            boxIn = true;
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(!boxIn)
            {
                isPlayerOnButton = false; // Karakter butondan ayr�ld���nda i�aretle
                StartCoroutine(TogglePlatformsAfterDelay(false, delayBeforeInvisible)); // Belirtilen s�re sonra platformlar� tekrar yar� g�r�n�r yap
            }
        }

        if (other.CompareTag("Box"))
        {
            isPlayerOnButton = false; // Karakter butondan ayr�ld���nda i�aretle
            StartCoroutine(TogglePlatformsAfterDelay(false, delayBeforeInvisible)); // Belirtilen s�re sonra platformlar� tekrar yar� g�r�n�r yap
            boxIn = false;
        }

    }

    private System.Collections.IEnumerator TogglePlatformsAfterDelay(bool visible, float delay)
    {
        float countdown = delay;

        // E�er kullan�lmak �zere bir TextMesh objesi atanm��sa, geri say�m� g�ncelle
        if (countdownText != null)
        {
            while (countdown > 0f)
            {
                countdownText.text = countdown.ToString("F1"); // Geri say�m� g�ncelle
                yield return new WaitForSeconds(0.1f); // K�sa bir bekleme s�resi ekleyerek geri say�m�n daha d�zenli g�r�nmesini sa�la
                countdown -= 0.1f;
            }

            countdownText.text = "0.0"; // Geri say�m bitti�inde s�f�r olarak g�ster
        }

        TogglePlatformsVisibility(visible); // Platformlar�n g�r�n�rl���n� ayarla
    }

    private void TogglePlatformsVisibility(bool visible)
    {
        foreach (GameObject platform in platformsToToggle)
        {
            platform.SetActive(visible); // Platformlar�n g�r�n�rl���n� ayarla
        }
    }
}
