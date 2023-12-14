using System.Collections.Generic;
using Management.Model;
using UnityEngine;

namespace View.UI.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private List<InventoryItemView> _inventoryItems;
        [SerializeField] private Color _equipColor;

        [SerializeField] private InventoryItemModal _itemModal;



        private void Start() {
            foreach (var item in _inventoryItems)
            {
                item.InventoryView = this;
            }
        }

        private void ClearInventory()
        {
            foreach (var item in _inventoryItems)
            {
                item.RemoveItem();
            }
        }

        public void UpdateInventory(CosmeticItem[] inventoryItems, CosmeticItem[] equipedItems)
        {
            ClearInventory();
            for (int i = 0; i < inventoryItems.Length; i++)
            {
                foreach (var item in equipedItems)
                {
                    if (item == inventoryItems[i]) {
                        _inventoryItems[i].EquipItem(_equipColor);
                    }
                }
                _inventoryItems[i].AddItem(inventoryItems[i]);
            }
        }

        public void OpenModal (CosmeticItem item) {
            _itemModal.gameObject.SetActive(true);
            _itemModal.SetUp(item);
        }
    }
}