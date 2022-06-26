public class OrderGate : InteractibleBase
{
    public override void Interact()
    {
        curInteractor.Character.OnStacksSort.Invoke();
    }
}
