using UnityEngine;
using DG.Tweening;

namespace BuildingCapluse
{
    [RequireComponent(typeof(QuickOutline))]
    public class OutlineManager : MonoBehaviour
    {
        private QuickOutline _outline;

        private const float OutlineWidth = 2f;

        private void Start()
        {
            _outline = GetComponent<QuickOutline>();
            _outline.OutlineWidth = 0f;
        }

        public void Select()
        {
            float timer = 0f;
            DOTween.To(() => timer, x => timer = x, 1, 0.25f)
                .OnUpdate(() =>
                {
                    _outline.OutlineWidth = Mathf.Lerp(0, OutlineWidth, timer);
                }); ;
        }

        public void Deselect()
        {
            float _outlineWidthOnDeselection = _outline.OutlineWidth;
            float timer = 0f;
            DOTween.To(() => timer, x => timer = x, 1, 0.25f)
                .OnUpdate(() =>
                {
                    _outline.OutlineWidth = Mathf.Lerp(_outlineWidthOnDeselection, 0, timer);
                });
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}