using DG.Tweening;
using UnityEngine.UI;

namespace Assets.Scipts.UI
{
    public class AppearanceAnimation : IAnimation
    {
        private readonly Graphic _target;
        private readonly float _duration;

        public float Duration => _duration;

        public AppearanceAnimation(Graphic target, float duration)
        {
            _target = target;
            _duration = duration;
        }

        public void SetInitialState()
        {
            _target.DOFade(0, 0);
        }

        public void StartAnimation()
        {
            _target.DOFade(1, _duration).SetEase(Ease.InSine);
        }
    }
}