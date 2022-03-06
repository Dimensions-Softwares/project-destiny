using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTopdown : MonoBehaviour
{
    //Sensibility above which we consider the player is moving
    private float sensibility = Common.MOVEMENT_SENSIBLITY;

    //Player's Components we need
    private Rigidbody2D rb;
    private Animator animator;

    //The player speed, can be modified in Unity
    [SerializeField] private float moveSpeed;

    private Vector2 movement;

    private bool isDashing;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movement = Vector2.zero;

    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        UpdateAnimatorParameters();
    }

    private void FixedUpdate()
    {
        if(!isDashing)
        {
            //Actual Movement application
            ApplyMovement();
        }
    }



    private void ApplyMovement()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void UpdateAnimatorParameters()
    {
        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
    }

    public void UpdateDash(bool newValue)
    {
        isDashing = newValue;
    }

}
