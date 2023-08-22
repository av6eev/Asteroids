using UnityEngine;

namespace Global.Pulls.Base
{
    public abstract class BasePullElementView : MonoBehaviour
    {
        public virtual void ChangeVisibility(bool state) => gameObject.SetActive(state);
    }
}