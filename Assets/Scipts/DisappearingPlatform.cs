using System.Collections;
using UnityEngine;

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
            StartCoroutine(Disappear());
        }
    }

    private IEnumerator Disappear()
    {
        float time = 0f;
        Color color = _spriteRenderer.color;

        while (time <= _timeToDisappear)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, time / _timeToDisappear); // Doing platform transparent by time
            _spriteRenderer.color = color;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
