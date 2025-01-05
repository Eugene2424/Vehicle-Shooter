using Game.Application;
using Game.Application.Abstractions;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Presentation.UI
{
    public class LoadingScreen : MonoBehaviour, ILoadingScreen
    {
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private Slider slider;
        
        public void Hide()
        {
            loadingScreen.SetActive(false);
        }

        public void Show()
        {
            loadingScreen.SetActive(true);
        }

        public void UpdateProgress(float progress)
        {
            slider.value = progress;
        }
    }
}