using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerPoint : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;

    private void Update()
    {
        Vector3 _targetPos = transform.position;
        _targetPos.x = _targetPoint.position.x;
        transform.position = Vector3.Lerp(transform.position, _targetPos, Time.deltaTime * 5f);
    }
}
