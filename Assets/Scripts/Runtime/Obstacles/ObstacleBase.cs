public class ObstacleBase : InteractibleBase
{
    protected IDamageable damageable;
    public override void Interact()
    {
        Damage();
    }

    protected virtual void Damage()
    {
        damageable = TryReachToObj<IDamageable>();
        if (damageable == null)
            return;

        damageable.TakeDamage();
    }
}
