using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    private void Awake()
    {
        GameManager.Instance.Weapons.Enqueue("punch");
        GameManager.Instance.Weapons.Enqueue("bow");

    }

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void Attack()
    {

        animator.SetTrigger("attack");
        animator.SetBool("isAttacking", true);
    }
}
