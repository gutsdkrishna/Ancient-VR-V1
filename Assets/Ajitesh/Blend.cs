using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Control the blend between animations using a parameter
        float blendValue = Mathf.PingPong(Time.time, 1f); // Example: PingPong between 0 and 1

        // Set the parameter value in the Animator
        animator.SetFloat("Blend", blendValue);
    }
}
