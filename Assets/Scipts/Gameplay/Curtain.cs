using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Curtain : MonoBehaviour
{
    private BoxCollider2D _collider;
    private Animator _animator;
    private int _allLiftCordAmount;
    private int _pulledLiftCordAmount;

    private void OnEnable()
    {
        LiftCord.PulledDown += HandleLiftCordPullDown;
    }

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _allLiftCordAmount = LiftCord.GetAmountOnScene();
    }

    private void OnDisable()
    {
        LiftCord.PulledDown -= HandleLiftCordPullDown;
    }

    public void Lift()
    {
        _collider.isTrigger = true;
        _animator.SetTrigger("Lift");
    }

    private void HandleLiftCordPullDown()
    {
        _pulledLiftCordAmount++;
        // Debug.Log("Incremented");

        if (_pulledLiftCordAmount == _allLiftCordAmount)
        {
            Lift();
            // Debug.Log("Opened");
        }
    }
}
