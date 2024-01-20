using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class AxeInteraction : MonoBehaviour
{
    public GameObject axePrefab; // Assign your axe prefab in the Unity Editor
    public Transform spawnPoint; // Assign the spawn point transform in the Unity Editor

    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    public float throwForce = 30f;
    private float originalTimeScale;
    public float torqueMagnitude = 10f;
    public float decreasedGravityFactor = 0.5f; // Adjust as needed
    public Canvas tutorialCanvas;
    public int damageAmount = 20;

    private GameObject newAxe; // Reference to the newly spawned axe

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
        if (tutorialCanvas != null)
        {
            tutorialCanvas.gameObject.SetActive(true);
        }
        // Store the original time scale
        originalTimeScale = Time.timeScale;

        // Slow down time for the tutorial effect
        Time.timeScale = 0.5f;
    }

    void OnRelease(XRBaseInteractor interactor)
    {
        if (tutorialCanvas != null)
        {
            tutorialCanvas.gameObject.SetActive(false);
        }
        // Restore the original time scale
        Time.timeScale = originalTimeScale;

        // Calculate the throw direction based on the camera's forward direction
        Vector3 throwDirection = Camera.main.transform.forward;

        // Spawn a new axe at the specified spawn point
        newAxe = SpawnNewAxe(spawnPoint.position, spawnPoint.rotation);

        // Disable the current axe after 7 seconds
        StartCoroutine(DisableAxeAfterDelay(7f));

        // Throw the new axe in the calculated direction
        ThrowAxe(newAxe, throwDirection);
    }

    GameObject SpawnNewAxe(Vector3 position, Quaternion rotation)
    {
        // Instantiate the new axe prefab at the specified position and rotation
        GameObject axe = Instantiate(axePrefab, position, rotation);

        // Enable the XRGrabInteractable on the new axe
        XRGrabInteractable newGrabInteractable = axe.GetComponent<XRGrabInteractable>();
        newGrabInteractable.enabled = true;

        return axe; // Return the reference to the newly spawned axe
    }

    void ThrowAxe(GameObject axeObject, Vector3 throwDirection)
    {
        // Get the Rigidbody of the newly spawned axe
        Rigidbody axeRb = axeObject.GetComponent<Rigidbody>();

        // Make the Rigidbody non-kinematic to enable physics
        axeRb.isKinematic = false;

        // Detach the axe from the player's hand
        axeObject.transform.parent = null;

        // Calculate the axis of rotation (around the AxeCenter point)
        Vector3 rotationAxis = Vector3.Cross(throwDirection, Vector3.up);

        // Apply force to throw the axe in the calculated direction
        axeRb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        // Optional: Rotate the axe while throwing
        axeRb.AddTorque(rotationAxis * torqueMagnitude, ForceMode.Impulse);

        // Decrease gravity (only for the axe)
        Vector3 opposingGravity = Physics.gravity * decreasedGravityFactor;
        axeRb.AddForce(opposingGravity, ForceMode.Acceleration);
    }

    IEnumerator DisableAxeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Disable the GameObject after the delay
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(transform.GetComponent<Rigidbody>());
        if (other.tag == "Enemy")
        {
            transform.parent = other.transform;
            other.GetComponent<ORCW>().TakeDamage(damageAmount);
        }
    }
}
