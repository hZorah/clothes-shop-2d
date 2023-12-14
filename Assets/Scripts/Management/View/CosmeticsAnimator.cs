using UnityEngine;


namespace View
{
    public class CosmeticsAnimator : MonoBehaviour
    {
        [SerializeField] private Animator[] _animators;

        public Animator[] Animators { get => _animators; }

        public void SetFloat (string name, float value) {
            foreach (var animator in _animators) {
                if (animator.enabled)
                    animator.SetFloat(name, value);
            }
        }

        public void SetBool (string name, bool value) {
            foreach (var animator in _animators) {
                if (animator.enabled)
                    animator.SetBool(name, value);
            }
        }
    }
}