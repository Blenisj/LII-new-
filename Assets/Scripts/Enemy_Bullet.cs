using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public float damage;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy")
        {
            Destroy(gameObject);
        }
        if(collision.GetComponent<Player_Health>() != null)
        {
            collision.GetComponent<Player_Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
