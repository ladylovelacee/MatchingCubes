using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractible
{
    void Interact(Interactor interactor);
    void Interact();
    void CutInteraction();
}
