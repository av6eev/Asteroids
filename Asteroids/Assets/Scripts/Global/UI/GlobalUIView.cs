using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Global.UI
{
    public class GlobalUIView : MonoBehaviour
    {
        [field: SerializeField] public Button PlayButton { get; private set; }
        [field: SerializeField] public Button ShopButton { get; private set; }
        [field: SerializeField] public Button HistoryButton { get; private set; }
        [field: SerializeField] public GameObject MainMenuRoot { get; private set; }

        public void ChangeVisibility(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}