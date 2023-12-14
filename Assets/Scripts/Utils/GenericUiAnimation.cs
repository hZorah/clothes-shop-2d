using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Utils
{
    public enum PopType
    {
        In,
        Out
    }
    public class GenericUiAnimation : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.3f;
        [SerializeField] private UnityEvent _OnFinishPopIn;
        [SerializeField] private float _scaleModifier;
        private float scale { get => _scaleModifier== 0 ? 1 : _scaleModifier; }
        private RectTransform myTransform;


        private void Awake() {
            myTransform = GetComponent<RectTransform>(); // caching transform
        }
        private void OnEnable() {
            StartCoroutine(PopRoutine(PopType.In));
        }

        public void Disable() {
            StartCoroutine(PopRoutine(PopType.Out));
        }
        IEnumerator PopRoutine( PopType type)
        {
            float start = 0;
            float finish = 0;
            float time = 0;

            switch (type)
            {
                case PopType.In:
                    start = 0;
                    finish = scale;
                    break;
                case PopType.Out:
                    start = scale;
                    finish = 0;
                    break;
            }

            while (time < _duration)
            {
                float scaleModifier = Mathf.Lerp(start, finish, time / _duration);
                myTransform.localScale = Vector3.one * scaleModifier;
                time += Time.deltaTime;
                yield return null;
            }
            if (type == PopType.Out)
                myTransform.gameObject.SetActive(false);
            if ( type == PopType.In) {
                _OnFinishPopIn?.Invoke();
            }
        }
    }
}