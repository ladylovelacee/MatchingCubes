using UnityEngine;

public class MoveablePart : MonoBehaviour
{
    [SerializeField]
    private CharacterData characterData;

    private float moveSpeed;

    private void Awake()
    {
        ResetSpeed();
        EventManager.OnSpeedChange.AddListener(SetMoveSpeed);
        EventManager.SetDefaultSpeed.AddListener(ResetSpeed);
    }

    private void OnDestroy()
    {
        EventManager.OnSpeedChange.RemoveListener(SetMoveSpeed);
        EventManager.SetDefaultSpeed.RemoveListener(ResetSpeed);
    }

    private void ResetSpeed()
    {
        moveSpeed = characterData.CharacterMovementData.ForwardSpeed;
    }

    private void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    private void FixedUpdate()
    {
        MoveBackward();
    }

    private void MoveBackward()
    {
        transform.position -= Vector3.forward * moveSpeed * Time.fixedDeltaTime;
    }
}
