using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTopdown : MonoBehaviour
{
    //Game Manager Instance
    private GameManager gameManager;

    //Player's Components we need
    private Rigidbody2D rb;
    private Animator animator;

    //Boolean to check player's state
    private bool dashing;
    private bool sprinting;

    private readonly string sprintButton = Inputs.SPRINT_BUTTON;

    //The player speed, can be modified in Unity
    [SerializeField] private float walkSpeed = 5.0f;
    [SerializeField] private float sprintSpeed = 8.5f;

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

        sprinting = Input.GetButton(sprintButton);
        UpdateAnimatorParameters();
    }

    private void FixedUpdate()
    {
        if(!dashing && !gameManager.InventoryManager.IsActive())
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
    }

    public void UpdateDash(bool newValue)
    {
        dashing = newValue;
    }
}
