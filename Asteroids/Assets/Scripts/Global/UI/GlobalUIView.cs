using Game.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Global.UI
{
    public class GlobalUIView : BaseGameUIView
    {
        [field: SerializeField] public Button PlayButton { get; private set; }
        [field: SerializeField] public Button ShopButton { get; private set; }
        [field: SerializeField] public Button HistoryButton { get; private set; }
        [field: SerializeField] public Button ExitButton { get; private set; }
        [field: SerializeField] public GameObject MainMenuRoot { get; private set; }
        [field: SerializeField] public GameObject Title { get; private set; }
    }
}