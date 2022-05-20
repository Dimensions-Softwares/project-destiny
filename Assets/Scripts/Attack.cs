using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Atack();
        }
    }

    void Atack()
    {
        animator.SetTrigger("attack");
        animator.SetBool("isAttacking", true);
    }
}
