public abstract class CollectibleBase : InteractibleBase, ICollectible
{
    protected Collector curCollector;
    private bool isCollected = false;

    public override void Interact()
    {
        curCollector = TryReachToObj<Collector>();
        if (curCollector == null)
            return;

        Collect(curCollector);
    }

    public virtual void Collect(Collector collector)
    {
        if (isCollected)
            return;

        isCollected = true;
        if(curCollector != collector)
            curCollector = collector;

        Collect();
    }

    public abstract void Collect();
}
