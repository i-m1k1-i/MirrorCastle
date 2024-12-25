using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Curtain : MonoBehaviour
{
    private BoxCollider2D _collider;
    private Animator _animator;
    private int _allLiftCordAmount;
    private int _pulledLiftCordAmount;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _allLiftCordAmount = LiftCord.GetAmountOnScene();
    }

    public void OpenUp()
    {
        _collider.isTrigger = true;
        _animator.SetTrigger("OpenUp");
    }

    public void OpenDown()
    {
        _collider.isTrigger = true;
        _animator.SetTrigger("OpenDown");
    }

    private void HandleLiftCordPullDown()
    {
        _pulledLiftCordAmount++;
        Debug.Log("Incremented");

        if (IsAllLiftCordPulled())
        {
            OpenUp();
            Debug.Log("Opened");
        }
    }

    private bool IsAllLiftCordPulled()
    {
        return _pulledLiftCordAmount == _allLiftCordAmount;
    }

    private void OnEnable()
    {
        LiftCord.PulledDown += HandleLiftCordPullDown;
    }

    private void OnDisable()
    {
        LiftCord.PulledDown -= HandleLiftCordPullDown;
    }
}
