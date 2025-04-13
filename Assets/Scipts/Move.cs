using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    private readonly string Horizontal = nameof(Horizontal);
    private readonly string JumpButton = nameof(Jump);

    [SerializeField, Range(1, 50)] private float _moveSpeed = 1;
    [SerializeField, Range(1, 50)] private float _jumpForce = 1f;
    [SerializeField] private Feet _feet;

    private Rigidbody2D _rb;
    private float _horizontalInput;

    public Feet Feet => _feet;

    public event UnityAction<float> Moved;
    public event UnityAction Stoped;
    public event UnityAction Jumped;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis(Horizontal);
        if (_horizontalInput != 0)
        {
            HandleMove();
            Moved?.Invoke(_horizontalInput);
        }
        else 
        {
            Stoped?.Invoke();
        }

        if (_feet.Grounded == true && Input.GetButtonDown(JumpButton))
        {
            Jump();
            Jumped?.Invoke();
        }
    }

    private void HandleMove()
    {
        float moveX = _horizontalInput * _moveSpeed * Time.deltaTime;
        Vector3 move = new(moveX, 0, 0);

        transform.position += move;
    }

    private void Jump()
    {
        Vector2 jumpVector = new (0, _jumpForce);
        _rb.AddForce(jumpVector, ForceMode2D.Impulse);
        Debug.Log("Jump complete");
    }
}
