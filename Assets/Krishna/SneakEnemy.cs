using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject invisibleBarrier;
    private Animator animator;

    void Start()
    {
        if (invisibleBarrier == null)
        {
            Debug.LogError("Invisible Barrier not assigned to the enemy script.");
        }

        // Get the Animator component
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the enemy GameObject.");
        }
    }

    void Update()
    {
        // Check if the enemy is defeated
        if (IsDefeated())
        {
            // Enable the invisible barrier
            SetBarrierActive(true);
        }
        else
        {
            // Disable the invisible barrier
            SetBarrierActive(false);
        }
    }

    bool IsDefeated()
    {
        // Check if the "Die" trigger is activated
        return animator != null && animator.GetCurrentAnimatorStateInfo(0).IsName("die");
    }

    void SetBarrierActive(bool active)
    {
        if (invisibleBarrier != null)
        {
            invisibleBarrier.SetActive(active);
        }
    }
}
