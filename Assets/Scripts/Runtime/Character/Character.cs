using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector]
    public StackEvent OnStackCollected = new StackEvent();

    [SerializeField]
    private CharacterData characterData;
    public CharacterData CharacterData => characterData;
    public CharacterMovementData MovementData => CharacterData.CharacterMovementData;

    
}
