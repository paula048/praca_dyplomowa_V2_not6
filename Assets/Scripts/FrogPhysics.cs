using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogPhysics : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void OnAnimatorMove()
    {
        if (animator && rb)
        {
            // Apply root motion to the Rigidbody's position, including Y (vertical) movement.
            // animator.deltaPosition contains the movement in all directions (X, Y, Z) from the animation.
            Vector3 newPosition = rb.position + animator.deltaPosition;

            // Move the Rigidbody (and BoxCollider) based on the root motion
            rb.MovePosition(newPosition);
        }
    }

}
