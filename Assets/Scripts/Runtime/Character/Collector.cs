using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class StackEvent : UnityEvent<IStackable> { }
public class Collector : MonoBehaviour, IDamageable
{
    #region Properties
    Character _character;
    Character Character => (_character == null) ? _character = GetComponent<Character>() : _character;

    Holder _holder;
    Holder Holder => (_holder == null) ? _holder = GetComponentInChildren<Holder>() : _holder;
    #endregion

    #region Private Field
    List<IStackable> stacks = new List<IStackable>();
    #endregion

    #region Methods From Monobehaviour
    private void OnEnable()
    {
        Character.OnStacksSort.AddListener(OrderById);
        Character.OnStacksShuffle.AddListener(ShuffleStacks);
    }

    private void OnDisable()
    {
        Character.OnStacksSort.RemoveListener(OrderById);
        Character.OnStacksShuffle.RemoveListener(ShuffleStacks);
    }

    #endregion

    #region Public Methods
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

        MoveUp(stack);

        stack.StackTransform.parent = Holder.transform;
        stack.StackTransform.localPosition = Vector3.zero;     
    }
    #endregion

    #region Private Methods
    private void MoveUp(IStackable stack)
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
            RemoveCollectible(stack);
            Destroy(stack.StackTransform.gameObject);
        }
    }

    private void OrderById()
    {
        List<IStackable> orderedList = stacks.OrderBy(x => x.StackID).ToList();
        UpdateLayout(GetStacksIDs(orderedList));
    }

    private void ShuffleStacks()
    {
        List<IStackable> shuffledList = new List<IStackable>(stacks);
        shuffledList.Shuffle();
        UpdateLayout(GetStacksIDs(shuffledList));
    }

    private List<string> GetStacksIDs(List<IStackable> stackables)
    {
        List<string> tempList = new List<string>();
        for (int i = 0; i < stackables.Count; i++)
        {
            tempList.Add(stackables[i].StackID);
        }

        return tempList;
    }

    private void UpdateLayout(List<string> stackables)
    {
        for (int i = 0; i < stackables.Count; i++)
        {
            stacks[i].StackID = stackables[i];
        }
    }
    #endregion

    #region Methods From Interfaces
    public void TakeDamage()
    {
        stacks.Last().StackTransform.SetParent(Holder.mover.transform);
        RemoveCollectible(stacks.Last());
        if (stacks.Count == 0)
            Debug.Log("Level fail");
    }
    #endregion
}
