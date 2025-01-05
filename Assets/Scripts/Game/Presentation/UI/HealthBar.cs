using UnityEngine;
using UnityEngine.UI;

namespace Game.Presentation.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        public void SetMaxHealth(int maxHealth)
        {
            slider.maxValue = maxHealth;
            slider.value = maxHealth;
        }

        public void SetHealth(int health)
        {
            slider.value = health;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}