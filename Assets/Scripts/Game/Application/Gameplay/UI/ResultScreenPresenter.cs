using System;
using Game.Application.Abstractions;
using Game.Application.Commands;
using Game.Application.Events;
using Game.Application.GameStates;

namespace Game.Application.Gameplay
{
    public class ResultScreenPresenter : IPresenter
    {
        private readonly IResultScreenView _view;
        private readonly EventBus _eventBus;
        private readonly ICommandMediator _mediator;

        public ResultScreenPresenter(IResultScreenView view, EventBus eventBus, ICommandMediator mediator)
        {
            _view = view;
            _eventBus = eventBus;
            _mediator = mediator;
        }

        public void Initialize()
        {
            _eventBus.Subscribe<GameStateEnterEvent>(HandleGameStateEnter);
            _view.OnPlayAgainButtonClicked += HandlePlayAgainButtonClicked;
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<GameStateEnterEvent>(HandleGameStateEnter);
            _view.OnPlayAgainButtonClicked -= HandlePlayAgainButtonClicked;
        }

        private void HandleGameStateEnter(GameStateEnterEvent evt)
        {
            if (evt.State == GameState.Win)
            {
                _view.ShowWinScreen();
            }
            else if (evt.State == GameState.Lose)
            {
                _view.ShowLoseScreen();
            }
        }

        private void HandlePlayAgainButtonClicked()
        {
            _mediator.Execute<PlayAgainCommand>();
        }
    }
}