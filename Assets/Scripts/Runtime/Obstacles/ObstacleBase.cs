public class ObstacleBase : InteractibleBase
{
    protected IDamageable damageable;
    public override void Interact()
    {
        damageable = TryReachToObj<IDamageable>();
        if (damageable == null)
            return;

        Damage();
    }

    protected virtual void Damage()
    {
        damageable.TakeDamage();
    }
}
