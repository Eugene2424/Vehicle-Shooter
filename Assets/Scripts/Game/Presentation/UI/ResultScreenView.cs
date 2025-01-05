using UnityEngine;
using UnityEngine.UI;
using System;
using Game.Application.Gameplay;

namespace Game.Presentation.UI
{
    public class ResultScreenView : MonoBehaviour, IResultScreenView
    {
        public event Action OnPlayAgainButtonClicked;
        [SerializeField] private GameObject winScreen, loseScreen;
        [SerializeField] private Button playAgainButton, playAgainButton2;

        private void Start()
        {
            playAgainButton.onClick.AddListener(() => OnPlayAgainButtonClicked?.Invoke());
            playAgainButton2.onClick.AddListener(() => OnPlayAgainButtonClicked?.Invoke());
        }

        private void OnDestroy()
        {
            playAgainButton.onClick.RemoveListener(() => OnPlayAgainButtonClicked?.Invoke());
            playAgainButton2.onClick.RemoveListener(() => OnPlayAgainButtonClicked?.Invoke());
        }

        public void ShowWinScreen()
        {
            winScreen.SetActive(true);
        }
        
        public void ShowLoseScreen()
        {
            loseScreen.SetActive(true);
        }
        
        public void Hide()
        {
            winScreen.SetActive(false);
            loseScreen.SetActive(false);
        }
    }
}