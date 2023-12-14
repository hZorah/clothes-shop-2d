using System.Collections.Generic;
using Management.Model;
using Presenter.Inventory;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace View.UI.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private List<InventoryItemView> _inventoryItems;
        [SerializeField] private Color _equipColor;
        [SerializeField] private GenericUiAnimation _animation;
        [SerializeField] private InventoryItemModal _itemModal;
    
        [SerializeField] private InventoryPresenter _inventoryPresenter;
        [SerializeField] private ScrollRect _scrollRect;


        private void Awake() {
            gameObject.SetActive(false);
            foreach (var item in _inventoryItems)
            {
                item.InventoryView = this;
            }
        }

        private void OnEnable() {
            _inventoryPresenter.UpdateInventory();
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

        public void Close() {
            _animation.Disable();
        }
        public void ResetScroll () {
            _scrollRect.verticalNormalizedPosition = 0;
        }
    }
}