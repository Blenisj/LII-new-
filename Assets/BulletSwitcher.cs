using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSwitcher : MonoBehaviour
{
    public GameObject[] bulletPrefabs; // Assign your bullet prefabs in the Inspector
    private int currentBulletIndex = 1;
    public float projectileForce = 10f;
    public float minDamage;
    public float maxDamage;
    AudioManager audioManager;
   



    void Update()
    {
        // Check for input to switch bullets
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchBullet();
        }

        // Example shooting logic on mouse click
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            ShootCurrentBullet();
            
        }
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void SwitchBullet()
    {
        currentBulletIndex++;
        if (currentBulletIndex >= bulletPrefabs.Length)
        {
            currentBulletIndex = 1; // Loop back to the first bullet type
        }

        // Optional: Update UI or visuals to indicate the current bullet type
    }

    void ShootCurrentBullet()
    {
        if (bulletPrefabs[currentBulletIndex] != null)
        {
            GameObject bullet = Instantiate(bulletPrefabs[currentBulletIndex], transform.position, Quaternion.identity);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mypos = transform.position;
            Vector2 direction = (mousePos - mypos).normalized;
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            if (bulletRb != null)
            {
                bulletRb.velocity = direction * projectileForce;
                Bullet bulletComponent = bullet.GetComponent<Bullet>();
                if (bulletComponent != null)
                {
                    bulletComponent.damage = Random.Range(minDamage, maxDamage);
                }
                audioManager.PlaySFX(audioManager.LaserGun);

            }
            else
            {
                Debug.LogError("No Rigidbody2D found on the bullet prefab!");
            }
        }
        else
        {
            Debug.LogError("Bullet prefab at index " + currentBulletIndex + " is not assigned!");
        }
    }
}
