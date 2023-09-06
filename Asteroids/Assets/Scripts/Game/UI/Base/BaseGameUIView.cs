using UnityEngine;

namespace Game.UI.Base
{
    public abstract class BaseGameUIView : MonoBehaviour
    {
        public void ChangeVisibility(bool state) => gameObject.SetActive(state);
    }
}