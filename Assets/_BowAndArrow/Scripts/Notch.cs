using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Notch : XRSocketInteractor
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);
        // Your implementation here
    }

    private void StoreArrow(XRBaseInteractable interactable)
    {
        // Your implementation here
    }

    private void TryToReleaseArrow(XRBaseInteractor interactor)
    {
        // Your implementation here
    }

    private void ForceDeselect()
    {
        // Your implementation here
    }

    private void ReleaseArrow()
    {
        // Your implementation here
    }

    public override XRBaseInteractable.MovementType? selectedInteractableMovementTypeOverride
    {
        get { return XRBaseInteractable.MovementType.Instantaneous; }
    }
}
