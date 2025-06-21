using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
       
    [SerializeField] private List<ActionBase> _executeWhenTouch;
    [SerializeField] private float _changeDestroy = 0.8f;

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<MovePlayer>(out var moveplayer))
        {
            foreach (ActionBase action in _executeWhenTouch)
            {
                if (moveplayer._isMoveVectorCheck && Random.value < _changeDestroy)
                {
                    action.Execute();
                    Destroy(gameObject, 0.8f);
                }
            }
        }
    }
}
