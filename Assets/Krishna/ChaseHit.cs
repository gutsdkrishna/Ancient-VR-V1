using UnityEngine;
using UnityEngine.AI;

public class ChaseHit : StateMachineBehaviour
{
    Transform player;
    NavMeshAgent agent;
    float followRange = 10f;
    bool shouldFollow = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get references to player and NavMeshAgent
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        // Set agent speed
        agent.speed = 5f;

        // Reset the follow condition
        shouldFollow = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check if the enemy should follow
        if (shouldFollow)
        {
            // Check if the player is within follow range
            float distance = Vector3.Distance(player.position, animator.transform.position);
            if (distance <= followRange)
            {
                // Set the player's position as the destination
                agent.SetDestination(player.position);
            }
            else
            {
                // If the player is out of range, transition to another state (e.g., idle)
                animator.SetBool("isFollowing", false);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Stop the enemy when exiting the follow state
        agent.SetDestination(animator.transform.position);
    }

    // Custom method to set the follow condition
    public void SetFollowCondition(bool shouldFollow)
    {
        this.shouldFollow = shouldFollow;
    }
}
