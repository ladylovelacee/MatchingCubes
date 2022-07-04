using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObjects/Character", order = 1)]
public class CharacterData : ScriptableObject
{
    public CharacterMovementData CharacterMovementData = new CharacterMovementData();

    public int MatchCountToFever = 3;
}

[System.Serializable]
public class CharacterMovementData
{
    public float ForwardSpeed = 6f;
    public float SlideSpeed = 8f;
}