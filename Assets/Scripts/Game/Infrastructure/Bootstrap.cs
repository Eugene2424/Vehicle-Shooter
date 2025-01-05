using Game.Application;
using Game.Application.GameStates;
using UnityEngine;
using Zenject;

namespace Game.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        private GameStateManager _stateManager;
        
        [Inject]
        public void Construct(GameStateManager stateManager)
        {
            _stateManager = stateManager;
        }

        private void Start()
        {
            _stateManager.ChangeState<MainMenuState>();
        }
    }
}