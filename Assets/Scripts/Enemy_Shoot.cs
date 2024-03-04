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
    public float cooldown;

    void Start()
    {
        StartCoroutine(ShootPlayer());
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(cooldown);
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
    }
}
