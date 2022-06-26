using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class StackEvent : UnityEvent<IStackable> { }
public class Collector : MonoBehaviour
{
    Character _character;
    Character Character => (_character == null) ? _character = GetComponent<Character>() : _character;

    Holder _holder;
    Holder Holder => (_holder == null) ? _holder = GetComponentInChildren<Holder>() : _holder;

    List<IStackable> stacks = new List<IStackable>();
    
    public void AddCollectible(IStackable stack)
    {
        if (stacks.Contains(stack))
            return;

        stacks.Add(stack);
        Character.OnStackCollected.Invoke(stack);
        CheckLastTriple();
    }

    public void RemoveCollectible(IStackable stack)
    {
        if (!stacks.Contains(stack))
            return;

        stacks.Remove(stack);
    }

    public void SetParentToHolder(IStackable stack)
    {
        if (!stacks.Contains(stack))
            return;

        UpdateLayout(stack);

        stack.StackTransform.parent = Holder.transform;
        stack.StackTransform.localPosition = Vector3.zero;     
    }

    private void UpdateLayout(IStackable stack)
    {
        for (int i = 0; i < stacks.Count; i++)
        {
            stacks[i].StackTransform.position += (Vector3.up * stack.StackSize.y);
        }
    }

    private const int MATCH_COUNT = 3;
    private void CheckLastTriple()
    {
        int stackCount = stacks.Count;
        if (stacks.Count < MATCH_COUNT)
            return;

        List<IStackable> temp = new List<IStackable>();
        temp.Add(stacks.Last());

        for (int i = 2; i <= MATCH_COUNT; i++)
        {
            if (stacks[stacks.Count - i].StackID == temp[temp.Count - 1].StackID)
                temp.Add(stacks[stacks.Count - i]);
            else
                break;
        }

        if (temp.Count == MATCH_COUNT)
            DestroyMatches(temp);
    }

    private void DestroyMatches(List<IStackable> matches)
    {
        foreach (IStackable stack in matches)
        {
            Destroy(stack.StackTransform.gameObject);
        }
    }
}
