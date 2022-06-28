using System.Collections;
using UnityEngine;

public class SpeederBoost : BoostBase
{
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
        SpeederBoost boost = curInteractor.Character.gameObject.AddComponent<SpeederBoost>();
        boost.Execute();
    }
}
