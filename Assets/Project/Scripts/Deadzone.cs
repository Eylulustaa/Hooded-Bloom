using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    public Vector3 RespawnLoc;
    [SerializeField] GameObject player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = RespawnLoc;
        }
    }
}
