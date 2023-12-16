using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabAndPopup : MonoBehaviour
{
    public Canvas popupCanvas;

    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener((args) => OnGrabbed(args));
            grabInteractable.selectExited.AddListener((args) => OnReleased(args));
        }

        // Hide the popup canvas initially
        popupCanvas.gameObject.SetActive(false);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        // Player grabbed the object, show the popup
        popupCanvas.gameObject.SetActive(true);

        // Disable player movement (if necessary)
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        // Player released the object, hide the popup
        popupCanvas.gameObject.SetActive(false);

        // Enable player movement (if necessary)
    }

    private void OnDestroy()
    {
        // Unsubscribe from the events when the script is destroyed
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener((args) => OnGrabbed(args));
            grabInteractable.selectExited.RemoveListener((args) => OnReleased(args));
        }
    }
}
