using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    Transform player;
    float attackRange = 3f; // Adjust this value based on your desired attack range

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Look at the player during the attack state
        animator.transform.LookAt(player);

        // Check the distance to the player
        float distance = Vector3.Distance(player.position, animator.transform.position);

        // If the player is out of attack range, stop attacking
        if (distance > attackRange)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Clean up any necessary actions when exiting the attack state
    }

    // Other state machine behaviour methods can be implemented if needed
}
