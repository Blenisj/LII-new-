using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        TakeInput();
        Move();
    }
    private void Move(){
        transform.Translate(direction * speed * Time.deltaTime);
        if (direction.x != 0|| direction.y != 0){
            SetAnimatorMovement(direction);
        }
        else{
            animator.SetLayerWeight(1, 0);
        }
        
    }    
    private void TakeInput(){
        direction = Vector2.zero;

        if(Input.GetKey(KeyCode.W)){
            direction += Vector2.up;
        }
        if(Input.GetKey(KeyCode.A)){
            direction += Vector2.left;
        }
        if(Input.GetKey(KeyCode.S)){
            direction += Vector2.down;
        }
        if(Input.GetKey(KeyCode.D)){
            direction += Vector2.right;
        }
    }
    private void SetAnimatorMovement(Vector2 direction){
        animator.SetFloat("xDir", direction.x);
        animator.SetFloat("yDir", direction.y);
        animator.SetLayerWeight(1, 1);
        if (direction.x != 0){
            animator.SetFloat("xDir", direction.x);
            animator.SetFloat("yDir", 0);
        }
        else if (direction.y != 0){
            animator.SetFloat("yDir", direction.y);
            animator.SetFloat("xDir", 0);
        }
    }

}
