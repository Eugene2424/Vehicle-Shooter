namespace Game.Application.Abstractions
{
    public interface ILoadingScreen
    {
        public void Show();
        public void Hide();
        public void UpdateProgress(float progress);
    }
}