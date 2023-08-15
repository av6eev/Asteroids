using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Health
{
    public class HealthView : BaseGameUIView
    {
        [field: SerializeField] public Image Mask { get; private set; }

        public void UpdateElement(float value)
        {
            Mask.fillAmount -= value;
        }
        
        public void SetStartedHealth(int maxHealth)
        {
            Mask.fillAmount = maxHealth;
        }
    }
}