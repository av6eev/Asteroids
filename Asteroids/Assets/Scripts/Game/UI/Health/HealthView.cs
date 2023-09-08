using Game.UI.Health.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Health
{
    public class HealthView : BaseHealthView
    {
        [field: SerializeField] public Image Mask { get; private set; }

        public override void UpdateHealth(float value) => Mask.fillAmount = value;

        public override void SetStartedHealth(int maxHealth) => Mask.fillAmount = maxHealth;
    }
}