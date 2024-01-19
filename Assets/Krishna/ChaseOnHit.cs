using UnityEngine;

public class EnemyHitHandler : MonoBehaviour
{
    public Animator enemyAnimator; // Assign the enemy's Animator component here in the Inspector
    public Collider enemyCollider; // Assign the enemy's Collider component here in the Inspector

    void OnTriggerEnter(Collider other)
    {
        // Check if the enemy is hit by the specific object (e.g., a weapon)
        if (other.CompareTag("Axe"))
        {
            // Enable the rage condition in the WalkAndRageState script
            if (enemyAnimator != null)
            {
                enemyAnimator.SetBool("isRaged", true);
            }

            // Optionally, trigger the rage animation state in the Animator
            if (enemyCollider != null)
            {
                enemyCollider.enabled = false; // Disable the collider after getting hit
            }
        }
    }

    // Method to enable the rage condition from external scripts
    public void EnableRageCondition()
    {
        if (enemyAnimator != null)
        {
            enemyAnimator.SetBool("isRaged", true);
        }
    }
}
