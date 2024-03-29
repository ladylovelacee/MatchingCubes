using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
    Rigidbody _rigidbody;
    Rigidbody CharacterRb => (_rigidbody == null) ? _rigidbody = GetComponent<Rigidbody>() : _rigidbody;

    public float sensitivityMultiplier = 0.01f;
    public float deltaThreshold = .1f;
    Vector2 firstTouchPosition;
    float finalTouchX;
    Vector2 curTouchPosition;

    public float minXPos = -1.25f;
    public float maxXPos = 1.25f;

    private void Update()
    {
        if (Managers.Instance == null)
            return;

        if (!LevelManager.Instance.IsLevelStarted)
            return;

        HandleMovementWithSlide();
    }

    void HandleMovementWithSlide()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            curTouchPosition = Input.mousePosition;
            Vector2 touchDelta = (curTouchPosition - firstTouchPosition);

            if (firstTouchPosition == curTouchPosition)
            {
                CharacterRb.velocity = new Vector3(0f, CharacterRb.velocity.y, CharacterRb.velocity.z);
            }

            //Debug.Log("firstTPos : " + firstTouchPosition + " - curTPos : " + curTouchPosition + " - touchDelta : " + touchDelta);
            finalTouchX = transform.position.x;

            if (Mathf.Abs(touchDelta.x) >= deltaThreshold)
            {
                finalTouchX = (transform.position.x + (touchDelta.x * sensitivityMultiplier));
            }

            finalTouchX = Mathf.Clamp(finalTouchX, minXPos, maxXPos);
            Vector3 newPos = new Vector3(finalTouchX, transform.position.y, transform.position.z);
            CharacterRb.position = Vector3.Lerp(CharacterRb.position, newPos, .5f);

            firstTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            ResetInputValues();
        }

    }

    void ResetInputValues()
    {
        CharacterRb.velocity = new Vector3(0f, CharacterRb.velocity.y, CharacterRb.velocity.z);
        CharacterRb.angularVelocity = new Vector3(0f, CharacterRb.angularVelocity.y, CharacterRb.angularVelocity.z);
        firstTouchPosition = Vector2.zero;
        finalTouchX = 0f;
        curTouchPosition = Vector2.zero;
    }
}
