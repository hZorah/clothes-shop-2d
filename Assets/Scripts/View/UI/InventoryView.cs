using System.Collections;
using System.Collections.Generic;
using Model.Management;
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

        public void UpdateInventory(List<CosmeticItem> items, CosmeticItem[] equipedItems)
        {

            ClearInventory();
            for (int i = 0; i < items.Count; i++)
            {
                _inventoryItems[i].AddItem(items[i]);
                foreach (var item in equipedItems)
                {
                    if (item == items[i]) {
                        _inventoryItems[i].EquipItem(_equipColor);
                    }
                }
            }
        }

        public void OpenModal (CosmeticItem item) {
            _itemModal.gameObject.SetActive(true);
            _itemModal.SetUp(item);
        }
    }
}