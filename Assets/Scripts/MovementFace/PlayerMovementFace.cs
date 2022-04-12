using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementFace : MonoBehaviour
{
    //Player's Components we need
    private Rigidbody2D rb;
    private Animator animator;
    
    //The player speed, can be modified in Unity
    [SerializeField] private float walkSpeed = 500;
    [SerializeField] private float sprintSpeed = 800;
    [SerializeField] private float dashSpeed = 1000;
    [SerializeField] private float dashDuration = 0.3f;

    private string sprintButton = "Fire3";
    private string dashButton = "Fire2";

    private float dashStartTime;

    private bool isSprinting;
    private bool isDashing;
    
    private float movementX;
    
    // Orientation du joueur : -1 = gauche et 1 = droite
    private float orientation;

    [HideInInspector] public bool isGrounded;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        isSprinting = Input.GetButton(sprintButton);

        if (Input.GetButton(dashButton) && !isDashing)
        {
            dashStartTime = Time.time;
            isDashing = true;
        }

        isDashing = isDashing && dashDuration >= Time.time - dashStartTime;

        animator.SetFloat("Horizontal", movementX);
        animator.SetFloat("Speed", movementX * movementX);
        animator.SetFloat("Orientation", orientation);
        
        if ((movementX * movementX) > 0.01)
        // On change l'orientation quand le joueur bouge    
        {
            orientation = movementX / Math.Abs(movementX);
        }

    }

    private void FixedUpdate()
    {
        if (isSprinting)
        {
            rb.velocity = new Vector2(sprintSpeed * Time.deltaTime * movementX, rb.velocity.y);
        } else if (isDashing)
        {
            rb.velocity = new Vector2(dashSpeed * Time.deltaTime * orientation, rb.velocity.y);
        } else
        {
            rb.velocity = new Vector2(walkSpeed * Time.deltaTime * movementX, rb.velocity.y);
        }
    }

}
