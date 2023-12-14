using System;
using System.Collections.Generic;
using UnityEngine;

namespace Management.Model.Shop
{
    public class ShopModel : MonoBehaviour
    {
        [SerializeField] private float _sellingMultiplier = 0.7f;
        [SerializeField] private List<CosmeticItem> _shopInventory;

        public float SellingMultiplier { get => _sellingMultiplier; }
        public CosmeticItem[] ShopInventory
        {
            get
            {
                CosmeticItem[] items = new CosmeticItem[_shopInventory.Count];
                _shopInventory.CopyTo(items);
                return items;
            }
        }

        public event Action OnInventoryUpdate;

        public void AddItem (CosmeticItem item) {
            _shopInventory.Add(item);
            OnInventoryUpdate?.Invoke();
        }

        public void Remove (CosmeticItem item) {
            _shopInventory.Remove(item);
            OnInventoryUpdate?.Invoke();
        }

        public bool Contains(CosmeticItem item) {
            return _shopInventory.Contains(item);
        }
    }
}