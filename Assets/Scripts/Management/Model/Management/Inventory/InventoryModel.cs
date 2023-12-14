using System;
using UnityEngine;

namespace Management.Model.Inventory
{
    public class InventoryModel : MonoBehaviour
    {
        [SerializeField] private CurrentMoneyModel _currentMoney;
        [SerializeField] private EquipedItemsModel _equipedItems;
        [SerializeField] private OwnedItemsModel _ownedItems;

        public event Action OnMoneyUpdate;
        public event Action OnEquipedItemsUpdate;
        public event Action OnInventoryUpdate;

        public float CurrentMoney { get => _currentMoney.CurrentMoney; }
        public CosmeticItem[] EquipedItems { get => _equipedItems.EquipedItems; }
        public CosmeticItem[] OwnedItems { get => _ownedItems.CosmeticItems; }

        public void IncreaseMoney (float amount) {
            _currentMoney.IncreaseMoney(amount);
            OnMoneyUpdate?.Invoke();
        }
        public void DecreaseMoney (float amount) {
            _currentMoney.DecreaseMoney(amount);
            OnMoneyUpdate?.Invoke();
        }

        public void EquipItem (CosmeticItem item){
            _equipedItems.EquipItem(item);
            OnEquipedItemsUpdate?.Invoke();
        }

        public void UnequipItem (CosmeticItem item){
            _equipedItems.UnequipItem(item);
            OnEquipedItemsUpdate?.Invoke();
        }

        public void AddToInventory (CosmeticItem item) {
            _ownedItems.AddToInventory(item);
            OnInventoryUpdate?.Invoke();
        }
         public void RemoveFromInventory (CosmeticItem item) {
            _ownedItems.RemoveFromInventory(item);
            OnInventoryUpdate?.Invoke();
        }

    }
}