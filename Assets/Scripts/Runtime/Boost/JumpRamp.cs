using UnityEngine;

public class JumpRamp : MonoBehaviour
{
    [SerializeField]
    private float jumpPower = 500;
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();
        if (rigidbody == null)
            return;
        rigidbody.AddForce(Vector3.up * jumpPower);
    }
}
