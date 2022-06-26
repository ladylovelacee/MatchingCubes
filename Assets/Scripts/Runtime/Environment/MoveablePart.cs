using UnityEngine;

public class MoveablePart : MonoBehaviour
{
    [SerializeField]
    private CharacterData characterData;

    private float moveSpeed;

    private void Awake()
    {
        SetValues();
    }

    private void Update()
    {
        MoveBackward();
    }

    private void SetValues()
    {
        moveSpeed = characterData.CharacterMovementData.ForwardSpeed;
    }

    private void MoveBackward()
    {
        transform.position -= Vector3.forward * moveSpeed * Time.deltaTime;
    }
}
