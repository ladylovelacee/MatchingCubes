using UnityEngine;

public class Stack : CollectibleBase, IStackable
{
    Renderer _renderer;
    Renderer Renderer => _renderer == null ? _renderer = GetComponentInChildren<Renderer>() : _renderer;

    [SerializeField]
    private string stackID;
    public string StackID { get => stackID; set => SetStackID(value); }

    public Vector3 StackSize => Renderer.bounds.size;

    public Transform StackTransform => transform;

    MaterialPropertyBlock propertyBlock;

    Tweens tween;
    [SerializeField]
    StackDataHolder stackData;

    private void Start()
    {
        tween = new Tweens(transform);
        ReloadCube();
    }
    
    private void SetStackID(string ID)
    {
        stackID = ID;
        ReloadCube();
    }

    private void ReloadCube()
    {
        propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetColor("_Color", stackData.GetColorByID(StackID));
        Renderer.SetPropertyBlock(propertyBlock);
    }

    public override void Collect()
    {
        curCollector.AddCollectible(this);
        curCollector.SetParentToHolder(this);

        tween.PunchScaleTween(stackData.StackTweenData.Punch, stackData.StackTweenData.Duration);
    }
}