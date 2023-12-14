using Management.Model;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(CosmeticsAnimator))]
    public class EquipItemView : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private CosmeticsAnimator _cosmeticAnimator;
        [SerializeField] private SpriteRenderer[] _renderers;


        public void EquipItem(CosmeticItem item)
        {
            _cosmeticAnimator.Animators[(int)item.Type].runtimeAnimatorController = item.AnimatorOverrideController;
            _cosmeticAnimator.Animators[(int)item.Type].enabled = true;
            _cosmeticAnimator.Animators[(int)item.Type].Play(_playerAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash);
            _renderers[(int)item.Type].sprite = item.DefaultSprite;
            _renderers[(int)item.Type].flipX = true;
        }

        public void RemoveItem(CosmeticItemType type)
        {
            _cosmeticAnimator.Animators[(int)type].runtimeAnimatorController = null;
            _cosmeticAnimator.Animators[(int)type].enabled = false;
            _renderers[(int)type].sprite = null;
        }
    }
}