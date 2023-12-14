using Management.Model;
using Management.Model.Shop;
using Presenter.Inventory;
using UnityEngine;

namespace Presenter.Shop
{
    public class ShopPresenter : MonoBehaviour
    {
        [SerializeField] private ShopModel _shopModel;
        [SerializeField] private InventoryPresenter _inventoryPresenter;
        [SerializeField] private GameObject _lowMoneyModal;

        private void Start() {
            _shopModel.OnInventoryUpdate += UpdateShop;
            UpdateShop();
        }
        private void OnDestroy() {
            _shopModel.OnInventoryUpdate -= UpdateShop;            
        }

        public void UpdateShop () {

        }
        public void Buy(CosmeticItem item)
        {
            if (_inventoryPresenter.IsItemInInventory(item))
            {
                // Indication for already own item
                return;
            }
            if (!_inventoryPresenter.HasMoneyFor(item))
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
            _inventoryPresenter.IncreaseMoney(item.Price);
            _inventoryPresenter.RemoveFromInventory(item);
        }
    }
}