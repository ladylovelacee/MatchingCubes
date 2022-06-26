using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleGate : InteractibleBase
{
    public override void Interact()
    {
        curInteractor.Character.OnStacksShuffle.Invoke();
    }
}
