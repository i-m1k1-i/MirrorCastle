using UnityEngine;
using YG;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IHasLayer
{
    [Header("Dependencies")]
    [SerializeField] private InputReader _input;
    [SerializeField] private Feet _feet;

    [Header("Movement settings")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 8f;

    [Header("Animation")]
    [SerializeField] private Animator _mainAnimator;
    [SerializeField] private SpriteRenderer _mainSpriteRenderer;
    [SerializeField] private Animator _transparentAnimator;
    [SerializeField] private SpriteRenderer _transparentSpriteRenderer;

    private DimensionController _dimensionController;
    private IMover _mover;
    private PlayerAnimationController _playerAnimatorController;

    private void Awake()
    {
        var rb = GetComponent<Rigidbody2D>();

        _dimensionController = new DimensionController(this, DimensionLayers.RealWorld);
        _mover = new Mover(transform, rb, _feet, _moveSpeed, _jumpForce);
        _playerAnimatorController = new PlayerAnimationController(_mainAnimator, _mainSpriteRenderer, _transparentAnimator, _transparentSpriteRenderer, _mover);
    }

    private void Update()
    {
        if (YG2.isPauseGame)
            return;

        _mover.HandleMove(_input.MoveInputValue);
    }

    private void OnEnable()
    {
        _input.SwitchDimensionEvent += _dimensionController.Switch;
        _input.JumpEvent += _mover.HandleJump;
    }

    private void OnDisable()
    {
        _input.SwitchDimensionEvent -= _dimensionController.Switch;
        _input.JumpEvent -= _mover.HandleJump;
    }

    private void OnDestroy()
    {
        _mover.Dispose();
        _playerAnimatorController.Dispose();
    }

    public void SetLayer(DimensionLayers layer)
    {
        gameObject.layer = (int)layer;
        _feet.gameObject.layer = (int)layer;
    }
}
