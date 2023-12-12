using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class OpenNoteOnCollision : MonoBehaviour
{
    [Header("UI Note")]
    public GameObject uiNote;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is on the XR rig layer
        if (other.gameObject.CompareTag("Player"))
        {
            // Open the UI note
            if (uiNote != null)
            {
                uiNote.SetActive(true);

                // Optionally, you can use XR Interaction Toolkit to disable interactivity during the note display
                XRGrabInteractable[] grabInteractables = GetComponentsInChildren<XRGrabInteractable>();
                foreach (var grabInteractable in grabInteractables)
                {
                    grabInteractable.enabled = false;
                }
            }
            else
            {
                Debug.LogWarning("UI note object is not assigned in the inspector.");
            }

            // Optionally, you can add additional logic here
            // For example, you might want to disable the collider after opening the note
            // GetComponent<Collider>().enabled = false;
        }
    }
}
