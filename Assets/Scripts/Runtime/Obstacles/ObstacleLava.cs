using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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
