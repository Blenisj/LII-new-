using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{
    public Transform player;
    public GameObject Projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float minCooldown;
    public float maxCooldown;
    public float spawnDistance = 1.0f;

    void Start()
    {
        StartCoroutine(ShootPlayer());
    }

    IEnumerator ShootPlayer()
    {
        float randomCooldown = Random.Range(minCooldown, maxCooldown);
        yield return new WaitForSeconds(randomCooldown);
        if (player != null)
        {
            GameObject shoot = Instantiate(Projectile, transform.position, Quaternion.identity);
            Vector2 mypos = transform.position;
            Vector2 playerpos = player.position;
            Vector2 direction = (playerpos - mypos).normalized;
            shoot.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            shoot.GetComponent<Enemy_Bullet>().damage = Random.Range(minDamage, maxDamage);
            StartCoroutine(ShootPlayer());
        }
        IEnumerator ShootPlayer()
        {
            yield return new WaitForSeconds(randomCooldown);
            if (player != null)
            {
                Vector2 mypos = transform.position;
                Vector2 playerpos = player.position;
                Vector2 direction = (playerpos - mypos).normalized;

                // Calculate an offset position in front of the enemy
                float spawnDistance = 1.0f; // Adjust this value based on the size of your enemy's collider
                Vector2 spawnPos = mypos + direction * spawnDistance;

                GameObject shoot = Instantiate(Projectile, spawnPos, Quaternion.identity);

                shoot.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
                shoot.GetComponent<Enemy_Bullet>().damage = Random.Range(minDamage, maxDamage);

                StartCoroutine(ShootPlayer());
            }
        }
    }
}
