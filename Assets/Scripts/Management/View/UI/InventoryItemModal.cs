using Management.Model;
using Presenter.Inventory;
using UnityEngine;

namespace View.UI.Inventory
{
    public class InventoryItemModal : MonoBehaviour
    {
        [SerializeField] private GenericUiAnimation _uiAnimation;
        [SerializeField] private InventoryPresenter _inventoryPresenter;
        [SerializeField] private CosmeticItem _cosmeticItem;
        [SerializeField] private GameObject _equipButton;
        [SerializeField] private GameObject _removeButton;
        [SerializeField] private bool _isItemEquiped;

        public void SetUp(CosmeticItem item)
        {
            _cosmeticItem = item;
            _isItemEquiped = _inventoryPresenter.IsItemEquiped(_cosmeticItem);
            _removeButton.SetActive(_isItemEquiped);
            _equipButton.SetActive(!_isItemEquiped);

        }

        public void EquipItem()
        {
            _inventoryPresenter.EquipItem(_cosmeticItem);
            Close();
        }
        public void RemoveItem() {
            _inventoryPresenter.UnequipItem(_cosmeticItem);
            Close();
        }
        public void DestroyItem () {
            _inventoryPresenter.RemoveFromInventory(_cosmeticItem);
            Close();
        }

        public void Close()
        {
            _uiAnimation.Disable();
        }
    }
}