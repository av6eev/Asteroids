using UnityEngine;
using UnityEngine.UI;

namespace Global.UI
{
    public class GlobalUIView : MonoBehaviour
    {
        [field: SerializeField] public Button PlayButton { get; protected set; }

        public void ChangeVisibility(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}