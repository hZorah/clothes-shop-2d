using Model.Management;
using UnityEngine;

[CreateAssetMenu(fileName = "CosmeticItem", menuName = "CosmeticItem")]
public class CosmeticItem : ScriptableObject {
    public string ItemName;
    public Sprite DefaultSprite;
    public AnimatorOverrideController AnimatorOverrideController;
    public CosmeticItemType Type;
    public float Price;
    
}