using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Quiver : XRSocketInteractor
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        // Your implementation here
    }

    private void CreateAndSelectArrow()
    {
        // Your implementation here
    }

    private Arrow CreateArrow()
    {
        // Your implementation here
        return null;
    }

    private void SelectArrow(Arrow arrow)
    {
        // Your implementation here
    }

    private void SetAttachOffset()
    {
        // Your implementation here
    }
}
