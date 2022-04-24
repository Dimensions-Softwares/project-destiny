using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SocialPlatforms;

public class Jump : MonoBehaviour
{
    private PlayerMovementFace playerMovementFace;

    [Range(1, 10)]
    public float jumpVelocity;
    
    // Gravity multiplier for the fall after jumping
    public float fallMultiplier = 2.5f;
    
    // Gravity multiplier to have lower jumps if we press the button for a shorter time
    public float lowJumpMultiplier = 2f;
    
    private Rigidbody2D rb;
    private bool isJumpPressed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovementFace = GetComponent<PlayerMovementFace>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && playerMovementFace.getIsGrounded())
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }

        isJumpPressed = Input.GetButton("Jump");
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
            // The player is falling
        {
            rb.velocity += Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime * Vector2.up;
        } else if (rb.velocity.y > 0 && !isJumpPressed)
            // The player is jumping upwards
        {
            rb.velocity += Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime * Vector2.up;
        }
    }
    
}
