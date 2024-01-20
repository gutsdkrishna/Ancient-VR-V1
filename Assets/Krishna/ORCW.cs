using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ORCW : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    private bool isDead = false;
    private NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component

    private void Start()
    {
        // Get the NavMeshAgent component
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead || animator.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            return; // If the enemy is already dead or dying, do nothing
        }

        HP -= damageAmount;
        if (HP <= 0)
        {
            Die();
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }

    private void Die()
    {
        isDead = true;
        animator.SetTrigger("die");
        //StartCoroutine(DestroyAfterDeath());

        // Disable the NavMeshAgent to stop movement
        if (navMeshAgent != null)
        {
            navMeshAgent.enabled = false;
        }
    }

    private IEnumerator DestroyAfterDeath()
    {
        yield return new WaitForSeconds(7f); // Wait for 7 seconds after death

        // Optionally, you can disable the GameObject or perform other actions
        gameObject.SetActive(false);
    }
}
