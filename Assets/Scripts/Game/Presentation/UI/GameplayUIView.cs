using Game.Application;
using Game.Application.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Presentation.UI
{
    public class GameplayUIView : MonoBehaviour, IGameplayUIView
    {
        [SerializeField] private GameObject gameplayUI;
        [SerializeField] private Slider distanceProgressSlider;
        
        public void Show()
        {
            gameplayUI.SetActive(true);
        }

        public void Hide()
        {
            gameplayUI.SetActive(false);
        }

        public void ShowRoadProgress()
        {
            distanceProgressSlider.gameObject.SetActive(true);
        }

        public void HideRoadProgress()
        {
            distanceProgressSlider.gameObject.SetActive(false);
        }

        public void SetMaxDistance(float value)
        {
            distanceProgressSlider.maxValue = value;
            distanceProgressSlider.value = value;
        }

        public void SetDistanceProgress(float progress)
        {
            distanceProgressSlider.value = progress;
        }
    }
}