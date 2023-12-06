using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string targetSceneName; // Specify the name of the scene you want to transition to

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Adjust the tag as needed
        {
            // Check if the target scene is different from the current scene
            if (SceneManager.GetActiveScene().name != targetSceneName)
            {
                // Load the target scene
                SceneManager.LoadScene(targetSceneName);
            }
            else
            {
                Debug.LogWarning("Trying to transition to the same scene. No action taken.");
            }
        }
    }
}
