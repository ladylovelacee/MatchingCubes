using UnityEngine;

public interface IStackable : ICollectible
{
    string StackID { get; }
    Vector3 StackSize { get; }
    Transform StackTransform { get; }
}
