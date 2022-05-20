using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Common;

public class PlayerMovementTopdown : MonoBehaviour
{
    //Sensibility above which we consider the player is moving
    private float sensibility = Common.MOVEMENT_SENSIBLITY;




    //Player's Components we need
    private Rigidbody2D rb;
    private Animator animator;




    private string sprintButton = "Fire3";

    //The player speed, can be modified in Unity
    [SerializeField] private float walkSpeed = 5.0f;
    [SerializeField] private float sprintSpeed = 8.5f;

    private Vector2 movement;

    public Vector2 Movement
    {
        get => movement;

        private set => movement = value;
    }

    private bool dashing;
    private bool sprinting;

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

        sprinting = Input.GetButton(sprintButton);
        UpdateAnimatorParameters();
    }

    private void FixedUpdate()
    {
        if(!dashing)
        {
            //Actual Movement application
            ApplyMovement(sprinting ? sprintSpeed : walkSpeed);
        }
    }



    private void ApplyMovement(float speed)
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void UpdateAnimatorParameters()
    {
        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

        if(movement.sqrMagnitude > 0)
        {
            animator.SetInteger("direction", GetPlayerDirection());
        }
    }

    private int GetPlayerDirection()
    {
        if(Mathf.Abs(movement.y) < Common.MOVEMENT_SENSIBLITY)
        {
            return GetHorizontalDirection(movement.x);
        } else
        {
            return GetVerticalDirection(movement.y);
        }
    }

    private int GetHorizontalDirection(float x_movement)
    {
        return (int)(x_movement > 0 ? DIRECTIONS.EAST : DIRECTIONS.WEST);
    }

    private int GetVerticalDirection(float y_movement)
    {
        return (int)(y_movement > 0 ? DIRECTIONS.NORTH : DIRECTIONS.SOUTH);
    }

    public void UpdateDash(bool newValue)
    {
        dashing = newValue;
    }

}
