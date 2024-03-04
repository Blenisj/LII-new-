using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{

    public float health;
    public float maxhealth;

    void Start()
    {
        health = maxhealth;
    }

    public void TakeDamage(float damage){
        health -= damage;
        CheckDeath();
    }

    private void CheckOverheal(){
        if (health > maxhealth){
            health = maxhealth;
        }
    }

    private void CheckDeath(){
        if (health <= 0){
            Destroy(gameObject);
        }
    }
}
