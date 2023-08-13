using Global.Dialogs.Base;
using Specifications.Ships;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Global.Dialogs.Shop.Card
{
    public class ShopCardDialogView : BaseDialogView
    {
        [field: SerializeField] public Image PreviewImage { get; private set; }
        [field: SerializeField] public TextMeshProUGUI TitleText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI PriceText { get; private set; }
        [field: SerializeField] public Button NextCardButton { get; private set; }
        [field: SerializeField] public Button PreviousCardButton { get; private set; }
        [field: SerializeField] public Button BuyButton { get; private set; }
        [field: SerializeField] public Button SelectButton { get; private set; }

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
        }

        public void SwitchButtons()
        {
            BuyButton.gameObject.SetActive(false);
            SelectButton.gameObject.SetActive(true);
        }
    }
}