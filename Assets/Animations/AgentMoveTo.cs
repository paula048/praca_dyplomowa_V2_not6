using UnityEngine;
using UnityEngine.AI;

public class FrogAI : MonoBehaviour {
    public NavMeshAgent agent;
    public Animator animator;
    public Transform target;  // Set this to the destination point

    void Start() {
        agent.updatePosition = false; // Use root motion
        agent.updateRotation = false;
    }

    void Update() {
        if (target != null) {
            agent.SetDestination(target.position);
        }

        animator.SetFloat("Speed", agent.velocity.magnitude); // Sync animation
    }

    void OnAnimatorMove() {
        agent.nextPosition = animator.rootPosition;
        transform.rotation = animator.rootRotation;
    }
}
