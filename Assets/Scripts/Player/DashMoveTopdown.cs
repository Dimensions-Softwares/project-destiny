using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInteract))]
public class DashMoveTopdown : MonoBehaviour
{
    //To know which direction the player will dash to
    private readonly float sensibility = Constants.MOVEMENT_SENSIBLITY;

    private readonly string dashButton = Inputs.DASH_BUTTON;
    
    private Rigidbody2D rb;
    private PlayerMovementTopdown moveScript; //We need the current movement direction of the player to know where to dash

    [SerializeField] 
    private float dashSpeed = 5f;
    [SerializeField] 
    private float dashDuration = 1f; //in seconds
    
    private float dashTime; //Internal variable to track the time elapsed since the current dash started
    private Vector2 movementDir; //The actual direction of the dash 

    private PlayerInteract playerInteract; //To check whether the player can dash


    private bool isDashing;
    public bool IsDashing
    {
        get => isDashing;
        private set
        {
            isDashing = value;
            moveScript.UpdateDash(value);
        }
    }

    private void Awake()
    {
        //Components Initialization
        rb = GetComponent<Rigidbody2D>();
        moveScript = GetComponent<PlayerMovementTopdown>();
        playerInteract = GetComponent<PlayerInteract>();
    }

    private void Start()
    {
        //Attributes Initialization
        movementDir = Vector2.zero;
        dashTime = dashDuration;
        IsDashing = false;
    }

    private void Update()
    {
        if (IsDashing)
        {
            dashTime -= Time.deltaTime; //Reduce the remaining dash time

            if (dashTime <= 0)
            {
                //When dash is finished, reset the values
                movementDir = Vector2.zero;
                dashTime = dashDuration;
                IsDashing = false;
            }
        }
        else
        {
            if (Input.GetButtonDown(dashButton) && CanDash())
            {
                IsDashing = true;
                
                if(moveScript.Movement.magnitude >= sensibility)
                {
                    movementDir = moveScript.Movement * dashSpeed; //Sets the movement vector
                }
                else
                {
                    movementDir = Constants.DEFAULT_DASH_DIRECTION * dashSpeed; //If the player is not moving => Dash in the default direction
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(IsDashing)
        {
            rb.velocity = movementDir; //Apply movement
        }
    }

    private bool CanDash()
    {
        return !playerInteract.IsInteracting; //Check if player can dash
    }
}
