using Game.UI.Health.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Health
{
    public class HealthView : MonoBehaviour, IHealthView
    {
        [field: SerializeField] public Image Mask { get; private set; }

        public void UpdateHealth(float value) => Mask.fillAmount = value;

        public void SetStartedHealth(int maxHealth) => Mask.fillAmount = maxHealth;
        
        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}