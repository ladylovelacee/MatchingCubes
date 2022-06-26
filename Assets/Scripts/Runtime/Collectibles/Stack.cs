using UnityEngine;
using System;

public class Stack : CollectibleBase, IStackable
{
    Renderer _renderer;
    Renderer Renderer => _renderer == null ? _renderer = GetComponentInChildren<Renderer>() : _renderer;

    [SerializeField]
    private string stackID;
    public string StackID => stackID;

    public Vector3 StackSize => Renderer.bounds.size;

    public Transform StackTransform => transform;

    Tweens tween;
    StackData stackData;

    private void Start()
    {
        tween = new Tweens(transform);
        stackData = new StackData();
    }

    public override void Collect()
    {
        curCollector.AddCollectible(this);
        curCollector.SetParentToHolder(this);

        tween.PunchScaleTween(stackData.Punch, stackData.Duration);
    }
}

[Serializable]
public class StackData
{
    [Header("Punch Tween Values")]
    public float Punch = .2f;
    public float Duration = .5f;
}