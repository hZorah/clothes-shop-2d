using UnityEngine;
using Model.Management;
using View;
using Presenter.Inventory;

public class EquipItemButton : MonoBehaviour
{
   // [SerializeField] private EquipItemView _equipItemView;
   [SerializeField] private CosmeticItem _cosmeticItem;

   [SerializeField] private InventoryPresenter _inventoryPresenter;

   public void Equip() {
    _inventoryPresenter.EquipItem(_cosmeticItem);
   }
}
