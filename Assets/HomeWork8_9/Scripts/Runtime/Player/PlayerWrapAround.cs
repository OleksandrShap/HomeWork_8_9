using UnityEngine;

public class PlayerWrapAround : MonoBehaviour
{
    [SerializeField] private float _buffer = 0.5f;

    private float _leftLimit;
    private float _rightLimit;
    

    private void Start()
    {
        var camera = Camera.main;

        Vector3 leftPoint = camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 rightPoint = camera.ViewportToWorldPoint(new Vector3(1, 0, 0));
        
        _leftLimit = leftPoint.x - _buffer;
        _rightLimit = rightPoint.x + _buffer;
        
    }

    private void Update()
    {
        CheckwrapAround();
    }

    private void CheckwrapAround()
    {
        Vector3 bufferPosition = transform.position;
        if (bufferPosition.x < _leftLimit)
        {
            bufferPosition.x = _rightLimit;
        }
        else if (bufferPosition.x > _rightLimit)
        {
            bufferPosition.x = _leftLimit;
        }
       
        transform.position = bufferPosition;
    }
}
