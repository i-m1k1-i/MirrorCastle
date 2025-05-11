using UnityEngine;

public class PlayerAnimationController : System.IDisposable
{
    private readonly string Moving = nameof(Moving);

    private readonly Animator _mainAnimator;
    private readonly SpriteRenderer _mainSpriteRenderer;
    private readonly Animator _transparentAnimator;
    private readonly SpriteRenderer _transparentSpriteRenderer;
    private readonly IMover _mover;

    public PlayerAnimationController(
        Animator mainAnimator,
        SpriteRenderer mainSpriteRenderer,
        Animator transparentAnimator,
        SpriteRenderer transparentSpriteRenderer,
        IMover mover)
    {
        _mainAnimator = mainAnimator;
        _mainSpriteRenderer = mainSpriteRenderer;
        _transparentAnimator = transparentAnimator;
        _transparentSpriteRenderer = transparentSpriteRenderer;
        _mover = mover;

        _mover.Moved += OnMoved;
        _mover.Stoped += OnStoped;
        _mover.Jumped += OnJumped;
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
        _mainAnimator.SetBool(Moving, moving);
        _transparentAnimator.SetBool(Moving, moving);
    }

    private void SetFlipX(bool flipX)
    {
        _mainSpriteRenderer.flipX = flipX;
        _transparentSpriteRenderer.flipX = flipX;
    }

    public void Dispose()
    {
        _mover.Moved -= OnMoved;
        _mover.Stoped -= OnStoped;
        _mover.Jumped -= OnJumped;
    }
}
