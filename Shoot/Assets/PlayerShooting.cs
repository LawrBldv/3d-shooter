using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab; // Bullet prefab
    [SerializeField] private Transform _shootPoint; // Position where the bullet spawns
    [SerializeField] private float _bulletSpeed = 10f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button to shoot
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Instantiate the bullet dynamically
        GameObject bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.velocity = _shootPoint.forward * _bulletSpeed;
        }

        Destroy(bullet, 5f); // Destroy bullet after 5 seconds to avoid clutter
    }
}
