using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORCW : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    private bool isDead = false;

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
        GetComponent<Collider>().enabled = false;
    }
}
