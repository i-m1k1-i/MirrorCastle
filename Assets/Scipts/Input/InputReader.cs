using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "ScriptableObjects/InputReader", order = 1)]
public class InputReader : ScriptableObject, GameInput.IPlayerActions, GameInput.IUIActions
{
    private GameInput _input;

    public float MoveInputValue => _input.Player.Move.ReadValue<float>();

    public event UnityAction SwitchDimensionEvent;
    public event UnityAction JumpEvent;

    public event UnityAction PauseEvent;


    private void OnEnable()
    {
        _input = new GameInput();
        _input.Player.SetCallbacks(this);
        _input.UI.SetCallbacks(this);
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    public void EnablePlayerInput()
    {
        _input.Player.Enable();
    }

    public void DisablePlayerInput()
    {
        _input.Player.Disable();
    }

    // Player Actions

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        { 
            JumpEvent?.Invoke();
            // Debug.Log("Jump event");
        }
    }

    public void OnSwitchDimension(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SwitchDimensionEvent?.Invoke();
            // Debug.Log("Switch dimension performed");
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        return;
    }

    // UI Actions

    public void OnTogglePause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PauseEvent?.Invoke();
        }
    }
}
