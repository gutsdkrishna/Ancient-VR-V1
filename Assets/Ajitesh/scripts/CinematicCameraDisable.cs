using UnityEngine;

public class DisableCameraForTime : MonoBehaviour
{
    public Camera cameraToDisable;
    public float disableTime = 5f;

    void Start()
    {
        // Make sure a camera is assigned
        if (cameraToDisable == null)
        {
            Debug.LogError("Camera not assigned to script! Please assign a camera.");
        }
        else
        {
            // Disable the camera initially
            cameraToDisable.enabled = false;

            // Enable the camera after a delay
            Invoke("EnableCamera", disableTime);
        }
    }

    void EnableCamera()
    {
        // Enable the camera after the specified time
        cameraToDisable.enabled = true;
    }
}
