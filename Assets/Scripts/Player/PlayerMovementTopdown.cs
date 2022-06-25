using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInteract))]
public class PlayerMovementTopdown : MonoBehaviour
{
    //Game Manager Instance
    private GameManager gameManager;

    //Player's Components we need
    private Rigidbody2D rb;
    private Animator animator;

    //Boolean to check player's state
    private bool isDashing;
    private bool isSprinting;

    private readonly string sprintButton = Inputs.SPRINT_BUTTON;

    //The player speed, can be modified in Unity
    [SerializeField] private float walkSpeed = 5.0f;
    [SerializeField] private float sprintSpeed = 8.5f;

    private PlayerInteract playerInteract;

    private Vector2 movement;

    public Vector2 Movement
    {
        get => movement;

        private set => movement = value;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerInteract = GetComponent<PlayerInteract>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameManager.Instance;
        movement = Vector2.zero;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        isSprinting = Input.GetButton(sprintButton);
        if (CanMove())
        {
            UpdateAnimatorParameters();
        }
    }

    private void FixedUpdate()
    {
        if(CanMove())
        {
            //Actual Movement application
            ApplyMovement(isSprinting ? sprintSpeed : walkSpeed);
        }
    }

    private bool CanMove()
    {
        return !isDashing && !gameManager.InventoryManager.IsActive() && !playerInteract.IsInteracting;
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
    }

    public void UpdateDash(bool newValue)
    {
        isDashing = newValue;
    }
}
