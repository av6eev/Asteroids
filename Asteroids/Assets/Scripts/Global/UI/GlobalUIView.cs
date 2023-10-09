using System;
using Global.UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Global.UI
{
    public class GlobalUIView : MonoBehaviour, IGlobalUIView
    {
        public event Action OnPlayClicked, OnShopClicked, OnHistoryClicked, OnExitClicked;
        
        [field: SerializeField] public Button PlayButton { get; private set; }
        [field: SerializeField] public Button ShopButton { get; private set; }
        [field: SerializeField] public Button HistoryButton { get; private set; }
        [field: SerializeField] public Button ExitButton { get; private set; }
        [field: SerializeField] public GameObject MainMenuRoot { get; private set; }
        [field: SerializeField] public GameObject Title { get; private set; }

        public void InitializeButtonsSubscriptions()
        {
            PlayButton.onClick.AddListener(() => { OnPlayClicked?.Invoke(); });
            ShopButton.onClick.AddListener(() => { OnShopClicked?.Invoke(); });
            HistoryButton.onClick.AddListener(() => { OnHistoryClicked?.Invoke(); });
            ExitButton.onClick.AddListener(() =>
            {
                OnExitClicked?.Invoke();
                Application.Quit();
            });
        }

        public void DisposeButtonsSubscriptions()
        {
            PlayButton.onClick.RemoveListener(() => { OnPlayClicked?.Invoke(); });
            ShopButton.onClick.RemoveListener(() => { OnShopClicked?.Invoke(); });
            HistoryButton.onClick.RemoveListener(() => { OnHistoryClicked?.Invoke(); });
            ExitButton.onClick.RemoveListener(() =>
            {
                OnExitClicked?.Invoke();
                Application.Quit();
            });
        }

        public void HideDecorationElements()
        {
            MainMenuRoot.SetActive(false);
            Title.SetActive(false);
        }
        
        public void ShowDecorationElements()
        {
            MainMenuRoot.SetActive(true);
            Title.SetActive(true);
        }

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}