using System.Collections;
public abstract class BoostBase : InteractibleBase, IBoost
{
    public void Execute()
    {
        StartCoroutine(ExecuteCo());
    }

    public abstract IEnumerator ExecuteCo();
    public abstract void Use();
    public override void Interact()
    {
        IBoost boost = curInteractor.gameObject.GetComponent<IBoost>();
        if (boost != null)
            boost.Interup();

        Use();
    }

    public void Interup()
    {
        StopAllCoroutines();
        Destroy(this);
    }
}
