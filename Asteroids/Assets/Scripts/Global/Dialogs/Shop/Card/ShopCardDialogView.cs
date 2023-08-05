using Specifications.Ships;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Global.Dialogs.Shop.Card
{
    public class ShopCardDialogView : MonoBehaviour
    {
        [field: SerializeField] public Image PreviewImage { get; private set; }
        [field: SerializeField] public TextMeshProUGUI TitleText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI PriceText { get; private set; }

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

        public void ChangeVisibility(bool state)
        {
            gameObject.SetActive(state);
        }
    }
}