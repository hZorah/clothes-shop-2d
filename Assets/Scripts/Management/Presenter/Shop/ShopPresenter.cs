using Management.Model;
using Management.Model.Shop;
using Management.View.UI.Shop;
using Presenter.Inventory;
using UnityEngine;

namespace Presenter.Shop
{
    public enum ShopMode
    {
        Buy,
        Sell
    }
    public class ShopPresenter : MonoBehaviour
    {
        public ShopMode ShopMode;
        [SerializeField] private ShopModel _shopModel;
        [SerializeField] private InventoryPresenter _inventoryPresenter;
        [SerializeField] private ShopView _shopView;

       



        private void Start()
        {
            _shopModel.OnInventoryUpdate += UpdateShop;
            UpdateShop();
        }
        private void OnDestroy()
        {
            _shopModel.OnInventoryUpdate -= UpdateShop;
        }

        

        public void SetBuyMode() {
            ShopMode = ShopMode.Buy;
            UpdateShop();
        }

        public void SetSellMode() {
            ShopMode = ShopMode.Sell;
            UpdateShop();
        }

        public void UpdateShop()
        {
            switch (ShopMode)
            {
                case ShopMode.Buy:
                    PopulateShopItems();
                    return;
                case ShopMode.Sell:
                    PopulatePlayerItems();
                    return;
            }

        }
        private void PopulatePlayerItems()
        {
            _shopView.UpdateShop(_inventoryPresenter.GetInventory(), _shopModel.SellingMultiplier);
        }
        private void PopulateShopItems()
        {
            _shopView.UpdateShop(_shopModel.ShopInventory, _shopModel.BuyingMultiplier);
        }
        public void Buy(CosmeticItem item)
        {
            if (_inventoryPresenter.IsItemInInventory(item))
            {
                // Indication for already own item
                return;
            }
            if (!HasMoneyToBuy(item))
            {
                // Low money
                return;
            }
            if (!_shopModel.Contains(item))
            {
                //Something went wrong
                return;
            }
            _inventoryPresenter.DecreaseMoney(item.Price);
            _inventoryPresenter.AddToInventory(item);
            _shopModel.Remove(item);
        }

        public bool HasMoneyToBuy(CosmeticItem item) {
            return _inventoryPresenter.HasMoneyFor(item.Price * _shopModel.BuyingMultiplier);
        }

        public void Sell(CosmeticItem item)
        {
            if (!_inventoryPresenter.IsItemInInventory(item))
            {
                // Indication for already own item
                return;
            }
            if (!_shopModel.Contains(item))
            {
                _shopModel.AddItem(item);
            }
            _inventoryPresenter.IncreaseMoney(item.Price * _shopModel.SellingMultiplier);
            _inventoryPresenter.RemoveFromInventory(item);
            UpdateShop();
        }
    }
}