using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !collected)
        {
            collected = true;
            gameObject.SetActive(false);
            LevelManager.Instance.CollectItem(); // GameManager'de toplandý sayýsýný artýr
        }
    }
}
