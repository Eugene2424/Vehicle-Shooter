using System;

namespace Game.Application.Gameplay
{
    public interface IMainMenuView
    {
        public event Action OnScreenClicked;
        public void ShowMenu();
        public void HideMenu();
    }
}