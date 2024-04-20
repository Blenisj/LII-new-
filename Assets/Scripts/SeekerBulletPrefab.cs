using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SeekerBulletPrefab : MonoBehaviour
{
    public GameObject seekerBulletPrefab;
    public Transform target;
    public int bulletsAmount = 4;
    public float startAngle = 90f, endAngle = 270f;
    private Vector2 bulletMoveDirection;
    public float shootingDelay = 0.5f;
    public float speed = 5f;

    
    void Start()
    {
        StartCoroutine(Shoot());
    }
    // This method sets the target the bullet should seek towards
    public void Seek(Transform _target)
    {
        target = _target;
    }

    private IEnumerator Shoot()
    

    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount; i++)
        {
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector2 bulletMoveDirection = (bulletVector - transform.position).normalized * speed;
         
            GameObject bullet = Instantiate(seekerBulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<SeekerBulletPrefab>().Seek(target); // Assuming you have a Transform 'target'

            angle += angleStep;
        }
      
        yield return new WaitForSeconds(shootingDelay);
    }
}


