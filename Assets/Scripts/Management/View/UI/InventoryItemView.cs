using Management.Model;
using UnityEngine;
using UnityEngine.UI;

namespace View.UI.Inventory
{
    public class InventoryItemView : MonoBehaviour
    {
        public InventoryView InventoryView;
        [SerializeField] private Image _icon;
        [SerializeField] private CosmeticItem _item;
        [SerializeField] private Image _background;

        private Color defaultColor;

        private void Awake() {
            _icon.enabled = false;
            defaultColor = _background.color;
        }

        public void AddItem (CosmeticItem item) {
            _item = item;
            _icon.enabled = true;
            _icon.sprite = item.Icon;
            Debug.Log("add" +  _icon.enabled );
        }
        public void RemoveItem () {
            _item = null;
            _icon.sprite = null;
            _icon.enabled = false;
            DeEquip();
        }

        public void EquipItem (Color equipColor) {
            Debug.Log("equip" + equipColor);
            _background.color = equipColor;
        }
        public void DeEquip () {
            _background.color = defaultColor;
            Debug.Log("dequip" + defaultColor);
        }
        public void OpenModal () {
            InventoryView.OpenModal(_item);
        } 
    }
}