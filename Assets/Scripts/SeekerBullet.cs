using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerBullet : MonoBehaviour
{
    public Transform target;
    public GameObject projectilePrefab;
    public int bulletsToShoot = 4;
    public float shootingDelay = 0.5f; // Delay between shots
    public float projectileForce = 10f;

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ShootSeekingProjectiles());
        }
    }

    IEnumerator ShootSeekingProjectiles()
    {
        for (int i = 0; i < bulletsToShoot; i++)
        {
            GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (target != null)
            {
                Vector2 direction = (target.position - transform.position).normalized;
                rb.velocity = direction * projectileForce;
            }
            else
            {
                // Handle the case where the target is missing or destroyed
                Debug.LogWarning("Target is missing!");
            }
            yield return new WaitForSeconds(shootingDelay);
        }
    }
}

