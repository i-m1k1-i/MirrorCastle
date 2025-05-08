using UnityEngine;
using YG;

[RequireComponent(typeof(Mover))]
public class Player : MonoBehaviour, IHasLayer
{
    [SerializeField] private InputReader _input;

    private DimensionController _dimensionController;
    private Mover _mover;

    public void SetLayer(DimensionLayers layer)
    {
        gameObject.layer = (int)layer;
        _mover.Feet.gameObject.layer = (int)layer;
    }

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _dimensionController = new DimensionController(this, DimensionLayers.RealWorld);
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
}
