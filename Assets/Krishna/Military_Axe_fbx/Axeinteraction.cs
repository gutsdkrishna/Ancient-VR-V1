using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AxeInteraction : MonoBehaviour
{
    public GameObject axePrefab; // Assign your axe prefab in the Unity Editor
    public Transform spawnPoint; // Assign the spawn point transform in the Unity Editor

    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    public float throwForce = 30f;
    private float originalTimeScale;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        // Subscribe to the grab events
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    void OnGrab(XRBaseInteractor interactor)
    {
        // Show your UI here
        // ...

        // Store the original time scale
        originalTimeScale = Time.timeScale;

        // Slow down time for the tutorial effect
        Time.timeScale = 0.2f;
    }

    void OnRelease(XRBaseInteractor interactor)
    {
        // Restore the original time scale
        Time.timeScale = originalTimeScale;

        // Calculate the throw direction based on the camera's forward direction
        Vector3 throwDirection = Camera.main.transform.forward;

        // Spawn a new axe at the specified spawn point
        SpawnNewAxe(spawnPoint.position, spawnPoint.rotation);

        // Disable the current axe
        //gameObject.SetActive(false);

        // Throw the axe in the calculated direction
        ThrowAxe(throwDirection);
    }

    void SpawnNewAxe(Vector3 position, Quaternion rotation)
    {
        // Instantiate the new axe prefab at the specified position and rotation
        GameObject newAxe = Instantiate(axePrefab, position, rotation);

        // Enable the XRGrabInteractable on the new axe
        XRGrabInteractable newGrabInteractable = newAxe.GetComponent<XRGrabInteractable>();
        newGrabInteractable.enabled = true;
    }

    void ThrowAxe(Vector3 throwDirection)
    {
        // Make the Rigidbody non-kinematic to enable physics
        rb.isKinematic = false;

        // Detach the axe from the player's hand
        transform.parent = null;

        // Apply force to throw the axe in the calculated direction
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        // Optional: Rotate the axe while throwing
        // rb.AddTorque(Vector3.up * 10f, ForceMode.Impulse);
    }
}
