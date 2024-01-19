using UnityEngine;
using UnityEngine.AI;

public class ChaseAfterRageState : StateMachineBehaviour
{
    Transform player;
    NavMeshAgent agent;

    public float chaseSpeed = 8f;
    public float delayBeforeChasing = 2.1f;

    private float timeSinceRaged;
    private bool isRaged;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 0f; // Set initial speed to zero

        timeSinceRaged = 0f;
        isRaged = animator.GetBool("isRaged");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check for changes in the isRaged boolean
        if (animator.GetBool("isRaged") != isRaged)
        {
            // Reset the timer when isRaged becomes true
            if (animator.GetBool("isRaged"))
                timeSinceRaged = 0f;

            // Update the stored isRaged value
            isRaged = animator.GetBool("isRaged");
        }

        // Increment the time since the isRaged became true
        timeSinceRaged += Time.deltaTime;

        // Check if enough time has passed before chasing
        if (timeSinceRaged >= delayBeforeChasing)
        {
            // Set the chase speed and start chasing the player
            agent.speed = chaseSpeed;
            agent.SetDestination(player.position);
        }
    }

    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        // Stop the agent when exiting the chase state
        agent.SetDestination(animator.transform.position);
        agent.speed = 0f; // Set speed to zero when exiting
    }
}
