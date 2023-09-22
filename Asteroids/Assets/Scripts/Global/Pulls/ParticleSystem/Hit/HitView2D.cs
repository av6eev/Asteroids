using Global.Pulls.ParticleSystem.Hit.Base;
using UnityEngine;

namespace Global.Pulls.ParticleSystem.Hit
{
    public class HitView2D : MonoBehaviour, IHitView
    {
        public void ChangeVisibility(bool state) => gameObject.SetActive(state);
        
        public void SetPosition(Vector3 newPosition) => transform.position = newPosition;
    }
}