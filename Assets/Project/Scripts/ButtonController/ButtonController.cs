using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject[] platformsToToggle; // Platformlarý tutmak için dizi
    public float delayBeforeInvisible = 3f; // Görünmez olmadan önce beklenilecek süre
    public float delayBeforeVisible = 0f; // Görünür olmadan önce beklenilecek süre

    public TextMesh countdownText; // 3D TextMesh objesi

    private bool isPlayerOnButton = false; // Karakter butonun üzerinde mi kontrol etmek için
    private bool boxIn = false;

    private void Start()
    {
        // Eðer kullanýlmak üzere bir TextMesh objesi atanmýþsa, baþlangýçta gösterilecek süreyi ayarla
        if (countdownText != null)
        {
            countdownText.text = delayBeforeVisible.ToString("F1"); // Baþlangýçta gösterilecek süreyi ayarla
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
            isPlayerOnButton = true; // Karakter butonun üzerine geldiðinde iþaretle
            StartCoroutine(TogglePlatformsAfterDelay(true, delayBeforeVisible)); // Belirtilen süre sonra platformlarý görünür yap
            boxIn = true;
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(!boxIn)
            {
                isPlayerOnButton = false; // Karakter butondan ayrýldýðýnda iþaretle
                StartCoroutine(TogglePlatformsAfterDelay(false, delayBeforeInvisible)); // Belirtilen süre sonra platformlarý tekrar yarý görünür yap
            }
        }

        if (other.CompareTag("Box"))
        {
            isPlayerOnButton = false; // Karakter butondan ayrýldýðýnda iþaretle
            StartCoroutine(TogglePlatformsAfterDelay(false, delayBeforeInvisible)); // Belirtilen süre sonra platformlarý tekrar yarý görünür yap
            boxIn = false;
        }

    }

    private System.Collections.IEnumerator TogglePlatformsAfterDelay(bool visible, float delay)
    {
        float countdown = delay;

        // Eðer kullanýlmak üzere bir TextMesh objesi atanmýþsa, geri sayýmý güncelle
        if (countdownText != null)
        {
            while (countdown > 0f)
            {
                countdownText.text = countdown.ToString("F1"); // Geri sayýmý güncelle
                yield return new WaitForSeconds(0.1f); // Kýsa bir bekleme süresi ekleyerek geri sayýmýn daha düzenli görünmesini saðla
                countdown -= 0.1f;
            }

            countdownText.text = "0.0"; // Geri sayým bittiðinde sýfýr olarak göster
        }

        TogglePlatformsVisibility(visible); // Platformlarýn görünürlüðünü ayarla
    }

    private void TogglePlatformsVisibility(bool visible)
    {
        foreach (GameObject platform in platformsToToggle)
        {
            platform.SetActive(visible); // Platformlarýn görünürlüðünü ayarla
        }
    }
}
