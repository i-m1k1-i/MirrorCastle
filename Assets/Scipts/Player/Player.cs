using UnityEngine;
using YG;

[RequireComponent(typeof(Mover), typeof(DimensionController))]
public class Player : MonoBehaviour
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
        _dimensionController = GetComponent<DimensionController>();
    }

    private void Update()
    {
        if (YG2.isPauseGame)
            return;

        _mover.TryMove(_input.MoveInput);
    }

    private void OnEnable()
    {
        _input.SwitchDimensionEvent += _dimensionController.Switch;
        _input.JumpEvent += _mover.TryJump;

        _input.RestartLevelEvent += GameManager.Instance.RestartLevel;
        _input.LevelSelectorEvent += GameManager.Instance.LoadLevelSelector;
    }

    private void OnDisable()
    {
        _input.SwitchDimensionEvent -= _dimensionController.Switch;
        _input.JumpEvent -= _mover.TryJump;

        _input.RestartLevelEvent -= GameManager.Instance.RestartLevel;
        _input.LevelSelectorEvent -= GameManager.Instance.LoadLevelSelector;
    }
}
