using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private readonly string Moving = nameof(Moving);

    [SerializeField] private Animator _transparentAnimator;
    [SerializeField] private SpriteRenderer _transparentSpriteRenderer;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Mover _mover;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _mover = GetComponent<Mover>();
    }

    private void OnEnable()
    {
        _mover.Moved += OnMoved;
        _mover.Stoped += OnStoped;
        _mover.Jumped += OnJumped;
    }

    private void OnDisable()
    {
        _mover.Moved -= OnMoved;
        _mover.Stoped -= OnStoped;
        _mover.Jumped -= OnJumped;
    }

    private void OnMoved(float direction)
    {
        SetMoving(true);

        if (direction < 0)
        {
            SetFlipX(true);
        }
        else if (direction > 0)
        {
            SetFlipX(false);
        }
    }

    private void OnStoped()
    {
        SetMoving(false);
    }

    private void OnJumped()
    {
        SetMoving(true);
    }

    private void SetMoving(bool moving)
    {
        _animator.SetBool(Moving, moving);
        _transparentAnimator.SetBool(Moving, moving);
    }

    private void SetFlipX(bool flipX)
    {
        _spriteRenderer.flipX = flipX;
        _transparentSpriteRenderer.flipX = flipX;
    }
}
