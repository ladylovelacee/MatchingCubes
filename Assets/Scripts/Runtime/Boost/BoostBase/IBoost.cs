using System.Collections;

public interface IBoost : IInteractible
{
    void Execute();
    IEnumerator ExecuteCo();
    void Interup();
}
