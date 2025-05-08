using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGameCompleted : MonoBehaviour
{
    [SerializeField] private TextAppearanceAnimation[] _textAnimations;
    [SerializeField] private Image _backgroundPanel;

    private void Start()
    {
        if (GameManager.Instance.PlayGameCompletedAnimation == false)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        float duration = 0;

        foreach (var textAnimation in _textAnimations)
        {
            textAnimation.StartAnimation();

            if (duration < textAnimation.Duration + textAnimation.Delay)
                duration = textAnimation.Duration + textAnimation.Delay;
        }

        yield return new WaitForSeconds(duration + 1);

        gameObject.SetActive(false);
    }
}
