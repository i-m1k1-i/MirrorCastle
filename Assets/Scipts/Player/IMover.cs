using UnityEngine.Events;

public interface IMover : System.IDisposable
{
    event UnityAction<float> Moved;
    event UnityAction Stoped;
    event UnityAction Jumped;

    void HandleJump();
    void HandleMove(float moveInput);
}