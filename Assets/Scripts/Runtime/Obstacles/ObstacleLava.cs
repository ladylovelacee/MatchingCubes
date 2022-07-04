using UnityEngine;

public class ObstacleLava : ObstacleBase
{
    public override void Interact()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        IMeltable meltable = other.GetComponent<IMeltable>();
        if (meltable == null) return;
        meltable.Melt();
    }
}
