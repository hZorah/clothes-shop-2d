using System;
using System.Collections.Generic;
using UnityEngine;


namespace Model.Management.Inventory
{
    [Serializable]
    public class OwnedItemsModel
    {
        [SerializeField] private InventoryExceptionMessages _errorMessages;
        [SerializeField] private List<CosmeticItem> _cosmeticItems;

        public List<CosmeticItem> CosmeticItems { get => _cosmeticItems; }

        public void AddToInventory (CosmeticItem item) {
            if (_cosmeticItems.Contains(item))
                throw new Exception(_errorMessages.AlreadyContains);
            
            _cosmeticItems.Add(item);
        }

        public void RemoveFromInventory (CosmeticItem item) {
            if (!_cosmeticItems.Contains(item))
                throw new Exception(_errorMessages.DontContain);
            
            _cosmeticItems.Remove(item);
        }
    }
}