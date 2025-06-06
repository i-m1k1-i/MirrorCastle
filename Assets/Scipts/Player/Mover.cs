using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : IMover
{
    private readonly float _moveSpeed = 1;
    private readonly float _jumpForce = 1f;

    private readonly Feet _feet;
    private readonly Rigidbody2D _rb;
    private readonly Transform _transform;

    public event UnityAction<float> Moved;
    public event UnityAction Stoped;
    public event UnityAction Jumped;

    public Mover(Transform transform, Rigidbody2D rb, Feet feet, float moveSpeed=1, float jumpForce=1)
    {
        _transform = transform;
        _rb = rb;
        _feet = feet;
        _moveSpeed = moveSpeed;
        _jumpForce = jumpForce;
    }

    public void HandleJump()
    {
        if (_feet.Grounded == true)
        {
            Jump();
            Jumped?.Invoke();
        }
    }

    public void HandleMove(float moveInput)
    {
        if (moveInput != 0)
        {
            Move(moveInput);
            Moved?.Invoke(moveInput);
        }
        else
        {
            Stoped?.Invoke();
        }
    }

    private void Move(float moveInput)
    {
        float moveX = moveInput * _moveSpeed * Time.deltaTime;
        Vector3 move = new(moveX, 0, 0);

        _transform.position += move;
    }

    private void Jump()
    {
        Vector2 jumpVector = new (0, _jumpForce);
        _rb.AddForce(jumpVector, ForceMode2D.Impulse);
        // Debug.Log("Jump complete");
    }

    public void Dispose()
    {
        Moved = null;
        Stoped = null;
        Jumped = null;
    }
}
