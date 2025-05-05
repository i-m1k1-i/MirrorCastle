namespace Assets.Scipts.UI
{
    public interface IAnimation
    {
        public float Duration { get; }

        void SetInitialState();
        void StartAnimation();
    }
}

