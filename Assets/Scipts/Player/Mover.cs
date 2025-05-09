using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField, Range(1, 50)] private float _moveSpeed = 1;
    [SerializeField, Range(1, 50)] private float _jumpForce = 1f;

    [SerializeField] private Feet _feet;

    private Rigidbody2D _rb;

    public Feet Feet => _feet;

    public event UnityAction<float> Moved;
    public event UnityAction Stoped;
    public event UnityAction Jumped;

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

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Move(float moveInput)
    {
        float moveX = moveInput * _moveSpeed * Time.deltaTime;
        Vector3 move = new(moveX, 0, 0);

        transform.position += move;
    }

    private void Jump()
    {
        Vector2 jumpVector = new (0, _jumpForce);
        _rb.AddForce(jumpVector, ForceMode2D.Impulse);
        // Debug.Log("Jump complete");
    }
}
