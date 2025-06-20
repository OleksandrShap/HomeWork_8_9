using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] protected Transform _targetPlayer;
    [SerializeField] private Rigidbody2D _playerRb;
    //[SerializeField] protected Transform _targetPlatform;
       

    [SerializeField] private List<ActionBase> _executeWhenTouch;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<MovePlayer>(out var moveplayer))
        {
            foreach (ActionBase action in _executeWhenTouch)
            {
                //if (_playerRb.linearVelocity.y < 0)
                    action.Execute();
            }
        }
    }
}
