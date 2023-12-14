using Model.Management;
using UnityEngine;

namespace Model.Management
{
[CreateAssetMenu(fileName = "CosmeticItem", menuName = "CosmeticItem")]
    public class CosmeticItem : ScriptableObject
    {
        public string ItemName;
        public Sprite DefaultSprite;
        public Sprite Icon;
        public AnimatorOverrideController AnimatorOverrideController;
        public CosmeticItemType Type;
        public float Price;

    }
}