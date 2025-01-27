using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform playerTransform;
    public bool followPlayer = true;
    public bool isToxicFrog = true;
    public float distanceThreshold = 20f;
    private Animator animator;

    

    void Start()
    {
        // Get the NavMeshAgent component
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Find the Player GameObject dynamically
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player GameObject not found. Make sure the Player has the correct tag.");
        }
    }

    void Update()
    {

        if(isToxicFrog){
                // Step 1: is Frog Detect Player?
                    // yes -> Attack
                    // no -> Normal


                // check distance between Player and Frog
                float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

                if (distanceToPlayer < distanceThreshold)
                {
                    // aby nie wywołało się ciagle, tylko przeszło do końca animacja
                    if(!followPlayer){
                        this.followPlayer = true;
                        animator.SetTrigger("agressiveMode");
                        animator.SetBool("isAgressive", true);
                        Debug.Log("TRIGGER distance: Frog Agressive");
                    }
                    
                }
                else{
                    // aby nie wywołało się ciagle, tylko przeszło do końca animacja
                    if(followPlayer){
                        this.followPlayer = false;
                        animator.SetTrigger("normaleMode");
                        animator.SetBool("isAgressive", false);
                    }
                    
                }


                if(followPlayer){

                            // Ensure the NavMeshAgent is active and placed on a NavMesh
        if (navMeshAgent.isOnNavMesh && playerTransform != null)
        {
            navMeshAgent.SetDestination(playerTransform.position);
        }
        else if (!navMeshAgent.isOnNavMesh)
        {
            Debug.LogError("ToxicFrog is not on a NavMesh. Ensure it starts on a valid baked NavMesh.");
        }
                }
        }
        //else normal Move

        
    }


    private void agressiveMode(){

    }



}

