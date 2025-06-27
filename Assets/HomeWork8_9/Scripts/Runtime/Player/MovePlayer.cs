using System;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private float _jumpForce = 3f;
    [SerializeField] private float _groundCheckDastance = 0.2f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _speed = 5f;

    //private bool _isMoveVectorCheck;

    public bool IsMoveVectorCheck { get; private set; }

    private bool _isFacing = true;
    private bool _isJump = false;
    private bool _isGrounded = false;

    void Update()
    {
        CaclculateJump();
        CheckMoveVector();
        SignalDistanceChange();
    }

   

    private void FixedUpdate()
    {
        if (_isGrounded && _isJump)
        {
            _playerRb.linearVelocity = Vector2.up * _jumpForce;
            _isJump = false;
        }

        CalculateMove();
    }

    private void CaclculateJump()
    {
        RaycastHit2D hit = Physics2D.Raycast(_playerRb.position, Vector2.down, _groundCheckDastance, _groundMask);
        _isGrounded = hit.collider != null;
        Debug.DrawRay(_playerRb.position, Vector2.down * _groundCheckDastance, Color.red);
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJump = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _isJump = false;
        }
    }

    private void CalculateMove()
    {
        float movement = Input.GetAxis("Horizontal");

        _playerRb.linearVelocity = new Vector2(movement * _speed, _playerRb.linearVelocity.y);

        if (_isFacing && movement < 0)
            Flip();
        else if (!_isFacing && movement > 0)
            Flip();
               
    }


    private void Flip()
    {
        _isFacing = !_isFacing;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void CheckMoveVector()
    {
        if(_playerRb.linearVelocity.y < -0.1f)
            IsMoveVectorCheck = true;
        else
            IsMoveVectorCheck = false;
    }

    private int CalculateDistance(float currentDistance, int playerDistance)
    {
        if (playerDistance < currentDistance)
        {
            return (int)currentDistance;
        }
        return playerDistance;
    }
    private void SignalDistanceChange()
    {
        PlayerModel.Distance = CalculateDistance(transform.position.y, PlayerModel.Distance);
        GameEvenBas.OnDistanceChange?.Invoke();
    }
}
