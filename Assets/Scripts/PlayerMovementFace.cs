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

    private Vector2 movement;
    // Orientation du joueur : -1 = gauche et 1 = droite
    private float orientation;

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
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Orientation", orientation);
        
        if (movement.sqrMagnitude > 0.01)
        // On change l'orientation quand le joueur bouge    
        {
            orientation = movement.x;
        }
        
        
    }

    private void FixedUpdate()
    {
        rb.velocity = moveSpeed * Time.deltaTime * movement;
    }

}
