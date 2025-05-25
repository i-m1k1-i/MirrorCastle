using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _duration;

    private void Start()
    {
        transform.DOMove(_endPoint.position, _duration).SetLoops(-1, LoopType.Yoyo);
    }
}
