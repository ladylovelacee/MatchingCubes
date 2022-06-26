public abstract class CollectibleBase : InteractibleBase, ICollectible
{
    protected Collector curCollector;
    private bool isCollected = false;

    public override void Interact()
    {
        if (!TryReachToCollector())
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

    private bool TryReachToCollector()
    {
        Collector collector = curInteractor.gameObject.GetComponent<Collector>();
        if (collector == null)
            curInteractor.gameObject.GetComponentInChildren<Collector>();

        if(collector == null)
            return false;

        curCollector = collector;
        return true;
    }
}
