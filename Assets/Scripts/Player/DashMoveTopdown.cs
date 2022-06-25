using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInteract))]
public class DashMoveTopdown : MonoBehaviour
{
    private float sensibility = Constants.MOVEMENT_SENSIBLITY;
    private string dashButton = "Fire2";
    
    private Rigidbody2D rb;
    private PlayerMovementTopdown moveScript;

    [SerializeField] 
    private float dashSpeed = 5f;
    [SerializeField] 
    private float startDashTime = 1f;
    
    private float dashTime;
    private Vector2 movementDir;

    private PlayerInteract playerInteract;


    private bool dashing;
    public bool IsDashing
    {
        get => dashing;
        private set
        {
            dashing = value;
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

    // Start is called before the first frame update
    private void Start()
    {

        //Attributes Initialization
        movementDir = Vector2.zero;
        dashTime = startDashTime;
        IsDashing = false;

    }

    // Update is called once per frame
    private void Update()
    {
        if (IsDashing)
        {
            dashTime -= Time.deltaTime;

            if (dashTime <= 0)
            {
                movementDir = Vector2.zero;
                dashTime = startDashTime;
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
                    movementDir = moveScript.Movement * dashSpeed;
                }
                else
                {
                    movementDir = Constants.DEFAULT_DASH_DIRECTION * dashSpeed;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(IsDashing)
        {
            rb.velocity = movementDir;
        }
    }

    private bool CanDash()
    {
        return !playerInteract.IsInteracting;
    }
}
