using UnityEngine;


namespace View
{
    public class CosmeticsAnimator : MonoBehaviour
    {
        [SerializeField] private Animator[] _animators;

        public void SetFloat (string name, float value) {
            foreach (var animator in _animators) {
                animator.SetFloat(name, value);
            }
        }

        public void SetBool (string name, bool value) {
            foreach (var animator in _animators) {
                animator.SetBool(name, value);
            }
        }
    }
}