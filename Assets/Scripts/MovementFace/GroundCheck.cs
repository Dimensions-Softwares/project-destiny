using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private PlayerMovementFace playerMovementFace;
    // Start is called before the first frame update
    void Start()
    {
        playerMovementFace = gameObject.transform.parent.GetComponent<PlayerMovementFace>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Platform"))
        {
            playerMovementFace.groundTouch();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Platform"))
        {
            playerMovementFace.groundLeave();
        }
    }
}
