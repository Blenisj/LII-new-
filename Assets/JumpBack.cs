using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBack : MonoBehaviour
{
    public Transform player;
    public float checkRadius = 5f;
    public Vector2 jumpForce = new Vector2(-5f, 5f);
    public LayerMask PlayerLayer;

    private Rigidbody2D rb;
    private bool isNearPlayer = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!player) // If player not assigned, try to find one by tag
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        // Check if player is within the checkRadius
        isNearPlayer = Physics2D.OverlapCircle(transform.position, checkRadius, PlayerLayer);

        // If the player is near and we are grounded (for jump purposes), then jump backward
        if (isNearPlayer && IsGrounded())
        {
            JumpBackward();
        }
    }

    void JumpBackward()
    {
        // Determine direction to jump back based on player's position
        Vector2 directionToPlayer = transform.position - player.position;
        directionToPlayer.Normalize(); // Normalize to get direction only

        // Apply jump force in opposite direction of player and upwards
        rb.AddForce(new Vector2(jumpForce.x * directionToPlayer.x, jumpForce.y), ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        // Check if the sprite is on the ground here to prevent jumping while in air
        // This can be implemented based on your game's logic, such as raycasting downward to check for ground
        return true; // Placeholder: replace with actual ground check
    }

    void OnDrawGizmosSelected()
    {
        // To visually debug the check radius in the Unity editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
