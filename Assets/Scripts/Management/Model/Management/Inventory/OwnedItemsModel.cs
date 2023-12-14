using System;
using System.Collections.Generic;
using UnityEngine;


namespace Management.Model.Inventory
{
    [Serializable]
    public class OwnedItemsModel
    {
        [SerializeField] private InventoryExceptionMessages _errorMessages;
        [SerializeField] private List<CosmeticItem> _cosmeticItems;

        public CosmeticItem[] CosmeticItems
        {
            get
            {
                CosmeticItem[] items = new CosmeticItem[_cosmeticItems.Count];
                _cosmeticItems.CopyTo(items);
                return items;
            }
        }

        public void AddToInventory(CosmeticItem item)
        {
            if (_cosmeticItems.Contains(item))
                throw new Exception(_errorMessages.AlreadyContains);

            _cosmeticItems.Add(item);
        }

        public void RemoveFromInventory(CosmeticItem item)
        {
            if (!_cosmeticItems.Contains(item))
                throw new Exception(_errorMessages.DontContain);

            _cosmeticItems.Remove(item);
        }
    }
}