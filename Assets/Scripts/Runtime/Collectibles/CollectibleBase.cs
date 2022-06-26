using UnityEngine;

public abstract class CollectibleBase : MonoBehaviour, ICollectible
{
    protected Collector curCollector;
    private bool isCollected = false;

    public virtual void Collect(Collector collector)
    {
        if (isCollected)
            return;

        isCollected = true;
        curCollector = collector;

        Collect();
    }

    public abstract void Collect();
}
