using System;

namespace Game.Application.Gameplay
{
    public interface IResultScreenView
    {
        public event Action OnPlayAgainButtonClicked;
        public void ShowWinScreen();
        public void ShowLoseScreen();
        public void Hide();
    }
}