using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkState : StateMachineBehaviour
{
    float timer;
    public string waypointTag = "Waypoint"; // Tag for the waypoints
    NavMeshAgent agent;
    Transform player;
    public float chaseRange = 30f;
    private List<Transform> wayPoints = new List<Transform>(); // Add this line to declare the list


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 5f;

        timer = 0;

        // Find waypoints with the specified tag
        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag(waypointTag);
        foreach (GameObject waypointObject in waypointObjects)
            wayPoints.Add(waypointObject.transform);

        // Set the initial destination to a random waypoint
        agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check if the agent has reached the current waypoint
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);

        // Update the timer
        timer += Time.deltaTime;

        // If the timer exceeds 10 seconds, stop patrolling
        if (timer > 10)
            animator.SetBool("isPatrolling", false);

        // Check the distance to the player and transition to chasing if within range
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange)
            animator.SetBool("isChasing", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Stop the agent from moving
        agent.SetDestination(agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
