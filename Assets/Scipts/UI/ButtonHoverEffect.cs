using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float _hoverScale = 1.2f;
    [SerializeField] private float _duration = 0.1f;

    private Vector3 _originalScale;

    private void Start()
    {
        _originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 targetScale = _originalScale * _hoverScale;
        StartCoroutine(Scale(targetScale));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(Scale(_originalScale));
    }

    private IEnumerator Scale(Vector3 targetScale)
    {
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0f;
        float currentStep;

        while (elapsedTime < _duration)
        {
            currentStep = elapsedTime / _duration;
            transform.localScale = Vector3.Lerp(startScale, targetScale, currentStep);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}
