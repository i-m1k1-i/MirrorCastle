using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class LiftCord : MonoBehaviour
{
    private bool _isPulledDown = false;
    private Animator _animator;

    public static event UnityAction PulledDown;

    public static int GetAmountOnScene()
    {
        LiftCord[] liftCords = FindObjectsByType<LiftCord>(FindObjectsSortMode.None);
        int amount = liftCords.Length;
        return amount;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        var collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
    }

    private void PullDown()
    {
        _isPulledDown = true;
        _animator.SetTrigger("PullDown");
        PulledDown?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (_isPulledDown)
        {
            return;
        }

        if (collider.TryGetComponent<Player>(out Player _))
        {
            PullDown();
            Debug.Log("Pulled Down");
        }
    }
}
