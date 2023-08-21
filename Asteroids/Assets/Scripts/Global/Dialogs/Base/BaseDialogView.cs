using UnityEngine;

namespace Global.Dialogs.Base
{
    public abstract class BaseDialogView : MonoBehaviour
    {
        public virtual void ChangeVisibility(bool state) => gameObject.SetActive(state);
    }
}