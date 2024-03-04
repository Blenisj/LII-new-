using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behavior : MonoBehaviour
{
   public Transform player;
   public float smoothSpeed;
   public Vector3 offset;

   void FixedUpdate()
   {
        if (player != null)
        {
            Vector3 newPos= Vector3.Lerp(transform.position, player.transform.position + offset, smoothSpeed);
            transform.position = newPos;
        }

   }
}
