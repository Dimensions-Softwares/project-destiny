using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DashMoveTopdown : MonoBehaviour
{
    private float sensibility = Common.MOVEMENT_SENSIBLITY;

    private enum Direction { None = 0, Right = 1, Left = 2, Up = 3, Down = 4 }

    
    private Rigidbody2D rb;
    private PlayerMovementTopdown moveScript;

    [SerializeField] 
    private float dashSpeed = 5f;
    [SerializeField] 
    private float startDashTime = 1f;
    
    private float dashTime;
    private Direction dir;
    private Vector2 dashMovement;


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

    // Start is called before the first frame update
    void Start()
    {
        dir = 0;
        rb = GetComponent<Rigidbody2D>();
        moveScript = GetComponent<PlayerMovementTopdown>();
        dashTime = startDashTime;
        isDashing = false;
        dashMovement = Vector2.zero;

    }

    // Update is called once per frame
    void Update()
    {
        if(dir == 0)
        {
            if (Input.GetAxisRaw("Horizontal") > sensibility)
            {
                dir = Direction.Right;
            }
            else if (Input.GetAxisRaw("Horizontal") < -sensibility)
            {
                dir = Direction.Left;
            }
            else if (Input.GetAxisRaw("Vertical") > sensibility)
            {
                dir = Direction.Up;
            }
            else if (Input.GetAxisRaw("Vertical") < -sensibility)
            {
                dir = Direction.Down;
            }
        } else
        {
            if(dashTime <= 0)
            {
                dir = 0;
                dashTime = startDashTime;
                IsDashing = false;
                dashMovement = Vector2.zero;
            }else
            {
                if (!isDashing)
                {
                    IsDashing = true;
                }

                dashTime -= Time.deltaTime;

                switch(dir)
                {
                    case Direction.Right:
                        dashMovement = Vector2.right * dashSpeed;
                        break;
                    case Direction.Left:
                        dashMovement = Vector2.left * dashSpeed;
                        break;
                    case Direction.Up:
                        dashMovement = Vector2.up * dashSpeed;
                        break;
                    case Direction.Down:
                        dashMovement = Vector2.down * dashSpeed;
                        break;
                }
            }

        }
    }

    private void FixedUpdate()
    {
        rb.velocity = dashMovement;
    }
}
