using UnityEngine;
using TMPro;
using System.Collections;
using Assets.Scipts.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextAppearanceAnimation : MonoBehaviour, IAnimation
{
    [SerializeField] private float _delay;
    [SerializeField] private float _duration;

    private TextMeshProUGUI _textMeshPro;

    private IAnimation _animation;

    public float Duration => _duration;
    public float Delay => _delay;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        _animation = new AppearanceAnimation(_textMeshPro, _duration);
    }

    public void StartAnimation()
    {
        StartCoroutine(StartAnimationWithDelay());
    }

    public void SetInitialState()
    {
        _animation.SetInitialState();
    }

    public IEnumerator StartAnimationWithDelay()
    {
        SetInitialState();

        yield return new WaitForSeconds(_delay);

        _animation.StartAnimation();
    }
}
