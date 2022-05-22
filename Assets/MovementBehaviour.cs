using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : StateMachineBehaviour
{

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isMoving", true);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isMoving", false); 
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        float horizontalVelocity = Mathf.Cos(animator.GetFloat("horizontal"));
        float verticalVelocity = Mathf.Sin(animator.GetFloat("vertical"));


       
        /*if (horizontalVelocity == 0 && verticalVelocity == 0)
        {

        }
        if (horizontalVelocity == 0 && verticalVelocity == 1)
        {

        }
        if (horizontalVelocity == 1 && verticalVelocity == 0)
        {

        }
        if (horizontalVelocity == 1 && verticalVelocity == 1)
        {

        }
        if (horizontalVelocity == 0 && verticalVelocity == -1)
        {

        }
        if (horizontalVelocity == -1 && verticalVelocity == 0)
        {

        }
        if (horizontalVelocity == -1 && verticalVelocity == -1)
        {

        }
        if (horizontalVelocity == 1 && verticalVelocity == -1)
        {

        }
        if (horizontalVelocity == -1 && verticalVelocity == 1)
        {

        }*/
    }


}
