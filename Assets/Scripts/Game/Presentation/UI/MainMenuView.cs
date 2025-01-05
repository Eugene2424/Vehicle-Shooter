using System;
using Game.Application;
using Game.Application.Commands;
using Game.Application.Gameplay;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game.Presentation.UI
{
    public class MainMenuView : MonoBehaviour, IMainMenuView
    {
        
        [SerializeField] private GameObject mainMenu;
        public event Action OnScreenClicked;

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                    OnScreenClicked?.Invoke();
            }
        }

        public void ShowMenu()
        {
            mainMenu.SetActive(true);
        }
        
        public void HideMenu()
        {
            mainMenu.SetActive(false);
        }
        
    }
}