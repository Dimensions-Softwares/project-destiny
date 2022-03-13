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
    [SerializeField] private float moveSpeed;

    private float movementX;
    
    // Orientation du joueur : -1 = gauche et 1 = droite
    private float orientation;

    [HideInInspector] public bool isGrounded;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movementX = 0;

    }

    private void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Horizontal", movementX);
        animator.SetFloat("Speed", movementX * movementX);
        animator.SetFloat("Orientation", orientation);
        
        if ((movementX * movementX) > 0.01)
        // On change l'orientation quand le joueur bouge    
        {
            orientation = movementX;
        }
        
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed * Time.deltaTime * movementX, rb.velocity.y);
    }

}
