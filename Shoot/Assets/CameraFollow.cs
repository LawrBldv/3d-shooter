using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player; // Reference to the player
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10); // Default offset

    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
            transform.LookAt(player); // Optional: Keep camera focused on the player
        }
    }
}
