using UnityEngine;

public class MoveablePart : MonoBehaviour
{
    [SerializeField]
    private CharacterData characterData;

    private float moveSpeed;

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        Initialize();
    }

    private void OnDestroy()
    {
        EventManager.OnSpeedChange.RemoveListener(SetMoveSpeed);
        EventManager.SetDefaultSpeed.RemoveListener(ResetSpeed);
    }

    private void Initialize()
    {
        ResetSpeed();
        GameManager.Instance.GameData.Mover = transform;

        EventManager.OnSpeedChange.AddListener(SetMoveSpeed);
        EventManager.SetDefaultSpeed.AddListener(ResetSpeed);
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
        if (Managers.Instance == null)
            return;

        if (!LevelManager.Instance.IsLevelStarted)
            return;

        MoveBackward();
    }

    private void MoveBackward()
    {
        transform.position -= Vector3.forward * moveSpeed * Time.fixedDeltaTime;
    }
}
