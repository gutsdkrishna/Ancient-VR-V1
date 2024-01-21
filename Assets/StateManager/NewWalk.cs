using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform centerPoint; // The center of the circle
    public float circleRadius = 5f; // The radius of the circle
    public float patrolDelay = 2f; // Delay between each waypoint change
    public Animator enemyAnimator;

    private NavMeshAgent agent;
    private bool isHit = false;
    private bool isRaged = false;
    private bool isRunning = false;
    private List<Transform> wayPoints = new List<Transform>(); // Add this line to declare the list

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(PatrolInCircle());
    }

    void Update()
    {
        // Check if the enemy is running and chase the player
        if (isRunning)
        {
            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
            agent.speed = 10f;
        }
    }

    Vector3 GetRandomPointInCircle()
    {
        // Generate a random point within the circle
        Vector2 randomPoint = Random.insideUnitCircle.normalized * circleRadius;
        Vector3 randomWaypoint = centerPoint.position + new Vector3(randomPoint.x, 0f, randomPoint.y);
        return randomWaypoint;
    }

    IEnumerator PatrolInCircle()
    {
        while (true)
        {
            yield return new WaitForSeconds(patrolDelay);

            if (!isHit && !isRaged && !isRunning)
            {
                // Check if there are waypoints in the list
                if (wayPoints.Count > 0)
                {
                    // Set the destination to a random waypoint
                    agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count - 1)].position);
                    agent.speed = 5f;
                }
                else
                {
                    // If no waypoints are available, move to a random point in the circle
                    agent.SetDestination(GetRandomPointInCircle());
                    agent.speed = 5f;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe"))
        {
            // Enemy is hit by a weapon
            isHit = true;

            // Optionally, trigger rage animation in the Animator
            if (enemyAnimator != null)
            {
                enemyAnimator.SetBool("isRaged", true);
                StartCoroutine(StartRunningAfterDelay());
            }
        }
    }

    IEnumerator StartRunningAfterDelay()
    {
        yield return new WaitForSeconds(1.15f); // Wait for 2 seconds
        isRaged = false;
        isRunning = true;

        // Optionally, trigger running animation in the Animator
        if (enemyAnimator != null)
        {
            enemyAnimator.SetBool("isRunning", true);
        }
    }
}
