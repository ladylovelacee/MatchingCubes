using System.Collections;
using UnityEngine;

public class SpeederBoost : BoostBase
{
    [SerializeField]
    private float acceleration = 8f;
    public override IEnumerator ExecuteCo()
    {
        EventManager.OnSpeedChange.Invoke(acceleration);
        yield return new WaitForSeconds(GameManager.Instance.GameData.SpeederTimer);
        EventManager.SetDefaultSpeed.Invoke();

        Destroy(this);
    }

    public override void Use()
    {
        Execute();
    }

    public override void Interup()
    {
        EventManager.SetDefaultSpeed.Invoke();
        base.Interup();
    }
}
