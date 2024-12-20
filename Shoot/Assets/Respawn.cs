using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 _roomMinBounds; // Bottom-left corner of the room
    [SerializeField] private Vector3 _roomMaxBounds; // Top-right corner of the room
    [SerializeField] private Button _respawnButton; // Reference to the respawn button UI
    [SerializeField] private GameObject _uiCanvas; // Reference to the UI canvas (optional)

    private void Start()
    {
        if (_respawnButton != null)
        {
            _respawnButton.onClick.AddListener(Respawn);
        }
    }

    public void Respawn()
    {
        // Generate a random position within the room bounds
        float x = Random.Range(_roomMinBounds.x, _roomMaxBounds.x);
        float y = Random.Range(_roomMinBounds.y, _roomMaxBounds.y);
        float z = Random.Range(_roomMinBounds.z, _roomMaxBounds.z);

        transform.position = new Vector3(x, y, z);
        Debug.Log($"Player respawned at: {transform.position}");

        // Hide the button or UI canvas after respawn
        if (_uiCanvas != null)
        {
            _uiCanvas.SetActive(false);
        }
        else if (_respawnButton != null)
        {
            _respawnButton.gameObject.SetActive(false);
        }
    }
}
