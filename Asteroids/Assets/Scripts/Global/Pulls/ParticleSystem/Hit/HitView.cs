using UnityEngine;

namespace Global.Pulls.ParticleSystem.Hit
{
    public class HitView : MonoBehaviour, IHitView
    {
        public void ChangeVisibility(bool state) => gameObject.SetActive(state);
    }
}