using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 0.01f;

   
    
    private void LateUpdate()    
    {
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        Vector3 smoothPositon = Vector3.Lerp(transform.position, _target.position, _speed);

        smoothPositon = new Vector3(transform.position.x, smoothPositon.y, -10f);
        transform.position = smoothPositon;
    }
}
