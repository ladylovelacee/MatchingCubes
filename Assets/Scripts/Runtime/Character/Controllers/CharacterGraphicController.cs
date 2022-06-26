using UnityEngine;

public class CharacterGraphicController : MonoBehaviour
{
    Character _character;
    Character Character => (_character == null) ? _character = GetComponentInParent<Character>() : _character;

    private void OnEnable()
    {
        Character.OnStackCollected.AddListener(MoveUp);
    }

    private void OnDisable()
    {
        Character.OnStackCollected.RemoveListener(MoveUp);
    }

    private void MoveUp(IStackable stack)
    {
        transform.position += (Vector3.up * stack.StackSize.y);
    }
}
