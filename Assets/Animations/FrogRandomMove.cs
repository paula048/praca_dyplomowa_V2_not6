using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogRandomMove : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        int randomRotation = Random.Range(0, 361); // Generates a random degree between 0 and 360
        animator.SetInteger("RotationDegree", randomRotation);

        // Use Random.Range to get a random number between 0 and 2 (inclusive)
        int choice = Random.Range(0, 3);

        if (choice == 0)
        {
            animator.SetTrigger("Idle");
        }
        else if (choice == 1)
        {
            animator.SetTrigger("TurnLeft");
        }
        else
        {
            animator.SetTrigger("TurnRight");
        }
       
    }



}

