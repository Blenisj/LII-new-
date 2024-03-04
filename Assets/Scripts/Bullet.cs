using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            if(collision.GetComponent<Enemy_Health>() != null)
            {
                collision.GetComponent<Enemy_Health>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
