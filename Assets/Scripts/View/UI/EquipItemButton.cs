using UnityEngine;
using View;

public class EquipItemButton : MonoBehaviour
{
   [SerializeField] private EquipItemView _equipItemView;
   [SerializeField] private CosmeticItem _cosmeticItem;

   public void Equip() {
    _equipItemView.EquipItem(_cosmeticItem);
   }
}
