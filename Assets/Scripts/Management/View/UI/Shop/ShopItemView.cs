using Management.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Management.View.UI.Shop
{
    public class ShopItemView : MonoBehaviour
    {
        public ShopView ShopView;

        [SerializeField] private CosmeticItem _cosmeticItem;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Image _icon;

        public void AddItem (CosmeticItem item, float priceMultiplier) {
            _cosmeticItem = item;
            _icon.enabled = true;
            _icon.sprite = _cosmeticItem.Icon;
            _priceText.enabled = true;
            _priceText.text = (_cosmeticItem.Price * priceMultiplier).ToString();
        }
        public void RemoveItem () {
            _cosmeticItem = null;
            _icon.enabled = false;
            _icon.sprite = null;
            _priceText.enabled = false;
            _priceText.text = string.Empty;
        }

        public void OpenModal () {
            if (_cosmeticItem == null) return;
            ShopView.OpenModal(_cosmeticItem);
        }
    }
}