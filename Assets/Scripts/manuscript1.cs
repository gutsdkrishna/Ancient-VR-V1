using UnityEngine;

public class XRPlayerCollision : MonoBehaviour
{
    public GameObject canvasToShow; // Assign the Canvas GameObject in the Inspector
    public string playerTag = "Player"; // Set the tag of your XR Origin Rig

    private void Start()
    {
        if (canvasToShow != null)
        {
            canvasToShow.SetActive(false); // Ensure the Canvas is initially hidden
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Player entered trigger zone");
            ShowCanvas();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Player exited trigger zone");
            HideCanvas();
        }
    }

    private void ShowCanvas()
    {
        if (canvasToShow != null)
        {
            canvasToShow.SetActive(true);
        }
    }

    private void HideCanvas()
    {
        if (canvasToShow != null)
        {
            canvasToShow.SetActive(false);
        }
    }
}
