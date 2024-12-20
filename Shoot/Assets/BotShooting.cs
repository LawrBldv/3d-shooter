using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Prefab for the bullet
    [SerializeField] private Transform shootPoint; // Position where bullets are spawned
    [SerializeField] private float shootInterval = 2f; // Time between shots
    [SerializeField] private float bulletSpeed = 10f; // Speed of the bullets

    private float _timeSinceLastShot = 0f;

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;

        if (_timeSinceLastShot >= shootInterval)
        {
            Shoot();
            _timeSinceLastShot = 0f;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = shootPoint.forward * bulletSpeed;
        }

        Destroy(bullet, 5f); // Destroy the bullet after 5 seconds to prevent clutter
    }
}
