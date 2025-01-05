namespace Game.Application.Gameplay
{
    public interface IGameplayUIView
    {
        public void Show();
        public void Hide();
        public void ShowRoadProgress();
        public void HideRoadProgress();
        
        public void SetMaxDistance(float value);
        public void SetDistanceProgress(float progress);
    }
}