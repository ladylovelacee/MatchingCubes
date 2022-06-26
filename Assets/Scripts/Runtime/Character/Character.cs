using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterData characterData;
    public CharacterData CharacterData => characterData;
    public CharacterMovementData MovementData => CharacterData.CharacterMovementData;

    
}
