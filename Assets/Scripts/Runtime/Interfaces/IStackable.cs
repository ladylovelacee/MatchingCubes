using UnityEngine;

public interface IStackable : ICollectible
{
    string StackID { get; set; }
    Vector3 StackSize { get; }
    Transform StackTransform { get; }
}
