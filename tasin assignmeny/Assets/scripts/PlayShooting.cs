using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayShooting : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float rocketSpeed = 20f;
    [SerializeField] private int maxAmmo = 10;

    private int currentAmmo;
    private int bulletType; 
    private void Start()
    {
        currentAmmo = maxAmmo;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) bulletType = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) bulletType = 1;
        if (Input.GetMouseButtonDown(0))
        {

            if (currentAmmo > 0) Shoot();
            else print("out of ammo!!! press R to reload");
        }
        
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            currentAmmo = maxAmmo;
            print("reloading");
        }
    }
    private void Shoot()
    {
        if (bulletType == 0)
        {

            var newBullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);
            var rb = newBullet.GetComponent<Rigidbody>();
            rb.AddForce(gun.forward * bulletSpeed, ForceMode.Impulse);
        }
        if (bulletType == 1)
        {

            var newBullet = Instantiate(rocketPrefab, gun.position, Quaternion.identity);
            var rb = newBullet.GetComponent<Rigidbody>();
            rb.AddForce(gun.forward * rocketSpeed, ForceMode.Impulse);
        }
        currentAmmo--;
        
    }

}
