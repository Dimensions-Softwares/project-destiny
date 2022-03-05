using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTopdown : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;


    [SerializeField] private float moveSpeed = 5f;
    private Vector2 movement;

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

        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
