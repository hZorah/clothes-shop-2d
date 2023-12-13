using UnityEngine;

namespace Model.Management.Inventory
{
    [CreateAssetMenu(fileName = "InventoryExceptionMessages", menuName = "InventoryExceptionMessages")]
    public class InventoryExceptionMessages : ScriptableObject
    {
        [Header("Money")]
        public string AddNegativeMoney = "Increasing a negative number";
        public string RemoveNegativeMoney = "Decreasing a negative number";
        public string NotEnoughMoney = "Not enough money for transaction";
        [Header("Equiped Items")]
        public string WrongItemType = "Item type does not exist";
        public string SlotEmpty = "Slot already empty";
        [Header("Owned Items")]
        public string AlreadyContains = "This item already exists in inventory";
        public string DontContain = "This item does not exist in inventory";
    }
}