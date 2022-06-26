using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : Singleton<CollectibleManager>
{
    List<ICollectible> collectibles = new List<ICollectible>();

    public void AddCollectible(ICollectible collectible)
    {
        if (collectibles.Contains(collectible)) return;

        collectibles.Add(collectible);
    }
    
    public void RemoveCollectible(ICollectible collectible)
    {
        if (!collectibles.Contains(collectible)) return;

        collectibles.Remove(collectible);
    }
}
