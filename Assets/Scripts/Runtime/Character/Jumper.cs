using UnityEngine;

public class Jumper : MonoBehaviour
{
    Rigidbody _rigidbody;
    Rigidbody CharacterRb => (_rigidbody == null) ? _rigidbody = GetComponent<Rigidbody>() : _rigidbody;

    private float gravity = -9.81f;
    [SerializeField]
    private float heigth;

    private Transform currentTarget;

    public void JumpToTarget(Transform target)
    {
        Physics.gravity = Vector3.up * gravity;
        currentTarget = target;
        CharacterRb.velocity = CalculateVelocity();
    }

    private Vector3 CalculateVelocity()
    {
        float displacementY = currentTarget.position.y - CharacterRb.position.y;
        Vector3 displacementXZ = new Vector3(currentTarget.position.x - CharacterRb.position.x, 0, currentTarget.position.z - CharacterRb.position.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * heigth);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * heigth / gravity) + Mathf.Sqrt(2 * (displacementY - heigth) / gravity));

        return velocityXZ + velocityY;
    }
}
