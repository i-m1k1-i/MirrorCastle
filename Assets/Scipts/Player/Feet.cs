using UnityEngine;

public class Feet : MonoBehaviour
{
    private readonly string Ground = nameof(Ground);

    [SerializeField] private bool _grounded = false;

    public bool Grounded => _grounded;


    private void Start()
    {
        Collider2D playerColllider = transform.parent.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(playerColllider, GetComponent<Collider2D>());
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_grounded) 
            return;

        Debug.Log("Collision Enter: " + other);
        if (IsGround(other))
        {
            _grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Collision Exit: " + other);
        if (IsGround(other))
        {
            _grounded = false;
        }
    }

    private bool IsGround(Collider2D other)
    {
        return other.CompareTag(Ground);
    }
}