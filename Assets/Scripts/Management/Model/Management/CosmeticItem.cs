using UnityEngine;

namespace Management.Model
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