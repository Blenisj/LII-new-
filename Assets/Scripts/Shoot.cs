using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject Projectile;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject shoot =Instantiate(Projectile, transform.position, Quaternion.identity);
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mypos = transform.position;
            Vector2 direction = (mousepos - mypos).normalized;
            shoot.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            shoot.GetComponent<Bullet>().damage = Random.Range(minDamage, maxDamage);
        }
    }
}
