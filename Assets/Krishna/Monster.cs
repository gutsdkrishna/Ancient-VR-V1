using UnityEngine;

public class DisableOnTrigger : MonoBehaviour
{
    public GameObject targetObject; // Assign the Emerald AI GameObject in the Inspector

    void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object is the target object
        if (other.gameObject == targetObject)
        {
            // Disable the Emerald AI GameObject
            if (targetObject != null)
            {
                // You might need to adjust this depending on how Emerald AI components are set up
                EmeraldAI.EmeraldAISystem aiSystem = targetObject.GetComponent<EmeraldAI.EmeraldAISystem>();
                if (aiSystem != null)
                {
                    aiSystem.gameObject.SetActive(false);
                    Debug.Log("Emerald AI GameObject Disabled");
                }
                else
                {
                    Debug.LogError("Emerald AI component not found on the target GameObject.", this);
                }
            }
            else
            {
                Debug.LogError("Target GameObject not assigned in the Inspector.", this);
            }
        }
    }
}
