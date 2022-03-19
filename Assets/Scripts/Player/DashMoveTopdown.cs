using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DashMoveTopdown : MonoBehaviour
{
    private float sensibility = Common.MOVEMENT_SENSIBLITY;
    private string dashButton = "Fire2";
    
    private Rigidbody2D rb;
    private PlayerMovementTopdown moveScript;

    [SerializeField] 
    private float dashSpeed = 5f;
    [SerializeField] 
    private float startDashTime = 1f;
    
    private float dashTime;
    private Vector2 movementDir;


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

    // Start is called before the first frame update
    void Start()
    {
        //Components Initialization
        rb = GetComponent<Rigidbody2D>();
        moveScript = GetComponent<PlayerMovementTopdown>();

        //Attributes Initialization
        movementDir = Vector2.zero;
        dashTime = startDashTime;
        IsDashing = false;

    }

    // Update is called once per frame
    void Update()
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
            if (Input.GetButtonDown(dashButton))
            {
                IsDashing = true;
                
                if(moveScript.Movement.magnitude >= sensibility)
                {
                    movementDir = moveScript.Movement * dashSpeed;
                }
                else
                {
                    movementDir = Common.defaultDashDirection * dashSpeed;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDir;
    }
}
