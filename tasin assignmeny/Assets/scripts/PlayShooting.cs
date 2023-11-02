using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayShooting : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 10f;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();

    }
    private void Shoot()
    {
        var newBullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);
        var rb = newBullet.GetComponent<Rigidbody>();
        rb.AddForce(gun.forward * bulletSpeed, ForceMode.Impulse);
    }

}
