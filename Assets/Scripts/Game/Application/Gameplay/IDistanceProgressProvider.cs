using System;

namespace Game.Application.Gameplay
{
    public interface IDistanceProgressProvider
    {
        public event Action OnDistanceFinished;
        public event Action<float> OnDistanceProgressChanged;

        public float GetDistance();
        public float GetDistanceProgress();
    }
}