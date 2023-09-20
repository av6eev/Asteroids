using UnityEngine;

namespace Global.Pulls.Base.PullElement
{
    public abstract class BasePullElementView : MonoBehaviour, IPullElementView
    {
        public virtual void ChangeVisibility(bool state) => gameObject.SetActive(state);
    }
}