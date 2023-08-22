using System.Globalization;
using Global.Dialogs.Base;
using Specifications.Ships;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Global.Dialogs.Shop.Card
{
    public class ShopCardDialogView : BaseDialogView
    {
        [field: Header("Ship Preview")]
        [field: SerializeField] public Image PreviewImage { get; private set; }
        [field: SerializeField] public TextMeshProUGUI TitleText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI PriceText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI GainedText { get; private set; }
        [field: SerializeField] public Button NextCardButton { get; private set; }
        [field: SerializeField] public Button PreviousCardButton { get; private set; }
        [field: SerializeField] public Button BuyButton { get; private set; }
        [field: SerializeField] public Button SelectButton { get; private set; }
        [field: Header("Ship Stats")]
        [field: SerializeField] public TextMeshProUGUI HealthStatText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI SpeedStatText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI AutomaticStatText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI ClipStatText { get; private set; }

        public void SetupCard(ShipSpecification specification)
        {
            if (specification.PreviewImage != null)
            {
                PreviewImage.sprite = specification.PreviewImage;
            }
            else
            {
                PreviewImage.gameObject.SetActive(false);
            }

            TitleText.text = specification.Name;
            PriceText.text = specification.Price.ToString();
            HealthStatText.text = specification.Health.ToString();
            SpeedStatText.text = specification.Speed.ToString(CultureInfo.InvariantCulture);
            AutomaticStatText.text = specification.IsAutomatic ? "Да" : "Нет";
            ClipStatText.text = specification.Count.ToString();
        }

        public void SwitchButtons(bool isPurchased)
        {
            BuyButton.gameObject.SetActive(!isPurchased);
            SelectButton.gameObject.SetActive(isPurchased);
        }

        public void ChangePriceText(bool isPurchased)
        {
            if (!isPurchased) return;
            
            PriceText.gameObject.SetActive(false);
            GainedText.gameObject.SetActive(true);
        }
    }
}