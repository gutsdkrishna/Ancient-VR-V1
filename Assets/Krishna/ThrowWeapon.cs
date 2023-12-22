using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowableWeapon : MonoBehaviour
{
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;
    private float throwForce = 10f;
    private float originalTimeScale;

    [System.Obsolete]
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb.isKinematic = true;

        // Use onSelectEntered with updated signature
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    void Update()
    {
        // Optionally, you can add logic for updating the UI during the grab.
    }

    void OnGrab(XRBaseInteractor interactor)
    {
        // Show UI (You can implement this part)
        // ...

        // Store the original time scale
        originalTimeScale = Time.timeScale;

        // Slow down time
        Time.timeScale = 0.5f;
    }

    void OnRelease(XRBaseInteractor interactor)
    {
        // Restore the original time scale
        Time.timeScale = originalTimeScale;

        // Check if the weapon is thrown
        if (rb != null && !rb.isKinematic)
        {
            // Throw the weapon
            ThrowWeapon();
        }
    }

    void ThrowWeapon()
    {
        // Make the Rigidbody non-kinematic to enable physics
        rb.isKinematic = false;

        // Detach the weapon from the player's hand
        transform.parent = null;

        // Apply force to throw the weapon forward
        rb.AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);

        // Optional: Rotate the weapon while throwing
        // rb.AddTorque(Vector3.up * 10f, ForceMode.Impulse);

        // Destroy the weapon after a delay (you can adjust this time)
        Destroy(gameObject, 5f);
    }
}
