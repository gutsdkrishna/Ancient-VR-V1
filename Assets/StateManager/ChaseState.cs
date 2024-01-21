using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player; // Replace with the actual VR headset GameObject

    // Set your desired distances
    public float chaseRange = 30f;
    public float attackRange = 3f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Change tag if necessary

        agent = animator.GetComponent<NavMeshAgent>();

        agent.speed = 6f;
        agent.stoppingDistance = attackRange; // Set stopping distance for attacking
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);




        
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, animator.transform.position);

            if (distance > chaseRange)
            {
                animator.SetBool("isChasing", false);
            }
            else
            {
                animator.SetBool("isChasing", true);

                if (distance < attackRange)
                {
                    animator.SetBool("isAttacking", true);
                }
                else
                {
                    animator.SetBool("isAttacking", false);
                }
            }
        }
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
    }
}
