using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public Animator enemyAnimator;

    private NavMeshAgent agent;
    private bool isHit = false;
    private bool isRaged = false;
    private bool isRunning = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNextWaypoint();
    }

    void Update()
    {
        if (!isHit && !isRaged && !agent.pathPending && agent.remainingDistance < 0.1f)
        {
            SetNextWaypoint();
        }

        // Check if the enemy is running and chase the player
        if (isRunning)
        {
            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
            agent.speed = 15f;
        }
    }

    void SetNextWaypoint()
    {
        if (waypoints.Count > 0)
        {
            int randomIndex = Random.Range(0, waypoints.Count);
            Transform nextWaypoint = waypoints[randomIndex];

            agent.SetDestination(nextWaypoint.position);
        }
        else
        {
            Debug.LogError("No waypoints available.");
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
