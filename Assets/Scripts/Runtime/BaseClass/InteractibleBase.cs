using UnityEngine;

public abstract class InteractibleBase : MonoBehaviour, IInteractible
{
    private bool isInteracted = false;
    protected Interactor curInteractor;

    public virtual void Interact(Interactor interactor)
    {
        if (isInteracted)
            return;

        isInteracted = true;
        curInteractor = interactor;

        Interact();
    }

    public abstract void Interact();

    public virtual void CutInteraction()
    {
        if (!isInteracted)
            return;

        isInteracted = false;
    }
}
