using UnityEngine;

public class Interactor : MonoBehaviour
{
    Character _character;
    public Character Character => (_character == null) ? _character = GetComponent<Character>() : _character;

    private void OnTriggerEnter(Collider other)
    {
        IInteractible interactible = other.GetComponent<IInteractible>();
        if (interactible == null)
            return;

        interactible.Interact(this);
    }

    private void OnTriggerExit(Collider other)
    {
        IInteractible interactible = other.GetComponent<IInteractible>();
        if (interactible == null)
            return;

        interactible.CutInteraction();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IInteractible interactible = collision.gameObject.GetComponent<IInteractible>();
        if (interactible == null)
            return;

        interactible.Interact(this);
    }

    private void OnCollisionExit(Collision collision)
    {
        IInteractible interactible = collision.gameObject.GetComponent<IInteractible>();
        if (interactible == null)
            return;

        interactible.CutInteraction();
    }
}
