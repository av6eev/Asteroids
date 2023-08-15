using UnityEngine;

namespace Game.UI
{
    public abstract class BaseGameUIView : MonoBehaviour
    {
        public virtual void ChangeVisibility(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}