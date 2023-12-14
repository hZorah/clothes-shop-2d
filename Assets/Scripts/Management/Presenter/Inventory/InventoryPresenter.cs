using Management.Model;
using Management.Model.Inventory;
using UnityEngine;
using View;
using View.UI.Inventory;

namespace Presenter.Inventory
{
    public class InventoryPresenter : MonoBehaviour
    {
        [SerializeField] private InventoryModel _inventoryModel;
        [SerializeField] private EquipItemView _equipItemView;
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private InventoryExceptionMessages _errorMessages;
        private void Start()
        {
            _inventoryModel.OnMoneyUpdate += UpdateMoney;
            _inventoryModel.OnEquipedItemsUpdate += UpdateEquipedItems;
            _inventoryModel.OnInventoryUpdate += UpdateInventory;

            UpdateMoney();
            UpdateEquipedItems();
        }

        private void OnDestroy()
        {
            _inventoryModel.OnMoneyUpdate -= UpdateMoney;
            _inventoryModel.OnEquipedItemsUpdate -= UpdateEquipedItems;
            _inventoryModel.OnInventoryUpdate -= UpdateInventory;
        }


        private void UpdateMoney()
        {

        }
        private void UpdateEquipedItems()
        {
            for (int i = 0; i < _inventoryModel.EquipedItems.Length; i++)
            {
                if (_inventoryModel.EquipedItems[i] == null)
                {
                    _equipItemView.RemoveItem((CosmeticItemType)i);
                }
                else
                {
                    _equipItemView.EquipItem(_inventoryModel.EquipedItems[i]);

                }
            }
            UpdateInventory();
        }
        public void UpdateInventory()
        {
            _inventoryView.UpdateInventory(_inventoryModel.OwnedItems, _inventoryModel.EquipedItems);
        }
        
        public bool HasMoneyFor (CosmeticItem item) {
            return _inventoryModel.CurrentMoney >= item.Price;
        }
        public bool IsItemInInventory(CosmeticItem item) {
            foreach (var i in _inventoryModel.OwnedItems)
            {
                if (i == item) return true;
            }
            return false;
        }

        public void EquipItem(CosmeticItem item)
        {
            if (!IsItemInInventory(item))
            {
                // This should not happen
                return;
            }
            try
            {
                _inventoryModel.EquipItem(item);
            }
            catch (System.Exception ex)
            {
                if (ex.Message == _errorMessages.WrongItemType)
                {
                    // This should not happen
                    return;
                }
            }
        }

        public bool IsItemEquiped(CosmeticItem item)
        {
            foreach (var i in _inventoryModel.EquipedItems)
            {
                if (i == item) return true;
            }
            return false;
        }

        public void UnequipItem(CosmeticItem item)
        {
            try
            {
                _inventoryModel.UnequipItem(item);
            }
            catch (System.Exception ex)
            {
                if (ex.Message == _errorMessages.SlotEmpty)
                {
                    // Play error soud
                    return;
                }
            }
        }

        public void IncreaseMoney(float amount)
        {
            try
            {
                _inventoryModel.IncreaseMoney(amount);
            }
            catch (System.Exception ex)
            {
                if (ex.Message == _errorMessages.AddNegativeMoney)
                {
                    // This should not happen
                    return;
                }
            }
        }

        public void DecreaseMoney(float amount)
        {
            try
            {
                _inventoryModel.DecreaseMoney(amount);
            }
            catch (System.Exception ex)
            {
                if (ex.Message == _errorMessages.RemoveNegativeMoney)
                {
                    // This should not happen
                    return;
                }
                if (ex.Message == _errorMessages.NotEnoughMoney)
                {
                    // Play error sound, maybe display some message
                    return;
                }
            }
        }

        public void AddToInventory(CosmeticItem item)
        {
            try
            {
                _inventoryModel.AddToInventory(item);
            }
            catch (System.Exception ex)
            {
                if (ex.Message == _errorMessages.AlreadyContains)
                {
                    // Play sound and error message
                    return;
                }
            }
        }

        public void RemoveFromInventory(CosmeticItem item)
        {
            try
            {
                if (IsItemEquiped(item))
                {
                    _inventoryModel.UnequipItem(item);
                }
                _inventoryModel.RemoveFromInventory(item);
            }
            catch (System.Exception ex)
            {
                if (ex.Message == _errorMessages.DontContain)
                {
                    // Play sound and error message
                    return;
                }
            }
        }
    }
}