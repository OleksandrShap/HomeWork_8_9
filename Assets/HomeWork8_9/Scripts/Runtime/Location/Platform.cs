using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] protected Transform _target;
    [SerializeField] protected Collider2D _collider;
    protected bool _isInitiated;

    private void Init(Transform target)
    {
        _target = target;
        _isInitiated = true;
    }

    protected virtual void OnUpdatePlatform()
    {
        if(_target.position.y > transform.position.y)
            _collider.enabled = true;
        else
            _collider.enabled = false;
    }
}
