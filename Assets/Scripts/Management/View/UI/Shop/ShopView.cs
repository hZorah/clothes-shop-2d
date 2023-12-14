using System.Collections.Generic;
using Management.Model;
using Presenter.Shop;
using UnityEngine;

namespace Management.View.UI.Shop
{
    public class ShopView : MonoBehaviour
    {
        [SerializeField] private List<ShopItemView> _shopIventory;
        [SerializeField] private ShopPresenter _shopPresenter;
        [SerializeField] private ShopModal _buyModal;
        [SerializeField] private ShopModal _sellModal;
        [SerializeField] private ShopModal _noMoneyModal;

        private void Start() {
            foreach (var item in _shopIventory)
            {
                item.ShopView = this;
            }
        }


        public void UpdateShop(CosmeticItem[] items, float priceMultiplier)
        {
            ClearShopInventory();
            for (var i = 0; i < items.Length; i++)
            {
                _shopIventory[i].AddItem(items[i], priceMultiplier);
            }
        }

        private void ClearShopInventory () {
            foreach (var item in _shopIventory)
            {
                item.RemoveItem();
            }
        }

        public void OpenModal (CosmeticItem item) {
            switch (_shopPresenter.ShopMode)
            {
                case ShopMode.Buy:
                   OpenBuyModal(item);
                    return;
                case ShopMode.Sell:
                    OpenSellModal(item);
                    return;
            }
        }

        private void OpenBuyModal (CosmeticItem item) {
            if (!_shopPresenter.HasMoneyToBuy(item))
            {
                _noMoneyModal.gameObject.SetActive(true);
                return;
            }
            _buyModal.gameObject.SetActive(true);
            _buyModal.SetUp(item);
        }
        private void OpenSellModal (CosmeticItem item) {
            _sellModal.gameObject.SetActive(true);
            _sellModal.SetUp(item);
        }
    }
}
