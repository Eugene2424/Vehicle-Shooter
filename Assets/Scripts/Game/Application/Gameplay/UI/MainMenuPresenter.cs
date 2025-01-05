using System;
using Game.Application.Abstractions;
using Game.Application.Commands;

namespace Game.Application.Gameplay
{
    public class MainMenuPresenter : IPresenter
    {
        private readonly IMainMenuView _view;
        private readonly ICommandMediator _mediator;

        public MainMenuPresenter(IMainMenuView view, ICommandMediator mediator)
        {
            _view = view;
            _mediator = mediator;
        }

        public void Initialize()
        {
            _view.ShowMenu();
            _view.OnScreenClicked += HandleScreenClicked;
        }

        public void Dispose()
        {
            _view.OnScreenClicked -= HandleScreenClicked;
        }

        private void HandleScreenClicked()
        {
            _view.HideMenu();
            _mediator.Execute<StartPlayingCommand>();
        }
    }
}