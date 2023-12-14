using System;
using UnityEngine;

namespace Model.Management.Inventory
{
    [Serializable]
    public class EquipedItemsModel
    {
        [SerializeField] private InventoryExceptionMessages _errorMessages;
        [SerializeField] private CosmeticItem[] _equipedItems; //needs to be in CosmeticItemType order

        public CosmeticItem[] EquipedItems { get => _equipedItems; }

        public void EquipItem (CosmeticItem item) {
            int type = (int)item.Type;
            if (type > _equipedItems.Length)
                throw new Exception(_errorMessages.WrongItemType);
            _equipedItems[type] = item;
        }

        public void UnequipItem (CosmeticItem item) {
            int type = (int)item.Type;
            if (type > _equipedItems.Length)
                throw new Exception(_errorMessages.WrongItemType);
            if (_equipedItems[type] == null)
                throw new Exception(_errorMessages.SlotEmpty);
            if (_equipedItems[type] != item)
                throw new Exception(_errorMessages.RemovingWrongItem);
            _equipedItems[type] = null;
        }

    }
}