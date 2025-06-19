using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 0.01f;

    private Vector3 _offset;
    
    private void LateUpdate()    
    {
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        //if (transform.position.y > _target.position.y) return;
        _offset = new Vector3(1f,-0.5f, _target.position.z);
        Vector3 desifedPosition = _target.position + _offset;
        Vector3 smoothPositon = Vector3.Lerp(transform.position, desifedPosition, _speed);

        smoothPositon = new Vector3(transform.position.x, smoothPositon.y, -10f);
        transform.position = smoothPositon;
    }
}
