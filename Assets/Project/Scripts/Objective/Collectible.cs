using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private bool collected = false;

    private float speed = 1f;
    private float distance = 0.4f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        float sinDegeri = Mathf.Sin(Time.time * speed);
        Vector3 NewPosition = startPos + new Vector3(0, sinDegeri * distance, 0);
        transform.position = NewPosition;
    }

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
