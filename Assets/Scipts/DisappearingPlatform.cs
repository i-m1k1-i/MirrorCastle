using System.Collections;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField] private float _timeToDisappear = 1.5f;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Disappearing trigger enter");
        if (other.TryGetComponent<Feet>(out Feet _))
        {
            Debug.Log("Disappearing");
            Disappear();
        }
         // Doing platform transparent by time
    }

    private void Disappear()
    {
        Color disapearedColor = _spriteRenderer.color;
        disapearedColor.a = 0f;
        _spriteRenderer.DOColor(disapearedColor, _timeToDisappear)
            .OnComplete(() => gameObject.SetActive(false));
    }
}
