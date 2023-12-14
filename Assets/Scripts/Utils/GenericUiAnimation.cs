using System.Collections;
using UnityEngine;

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
                    finish = 1;
                    break;
                case PopType.Out:
                    start = 1;
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
        }
    }
}