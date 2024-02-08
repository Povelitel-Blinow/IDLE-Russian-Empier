using UnityEngine;
using DG.Tweening;

namespace BuildingCapluse
{
    [RequireComponent(typeof(QuickOutline))]
    public class OutlineManager : MonoBehaviour
    {
        private QuickOutline _outline;

        private const float OutlineMaxWidth = 2f;

        private void Start ()
        {
            _outline = GetComponent<QuickOutline>();
            _outline.OutlineWidth = 0f;
        }

        public void Select()
        {
            float outlineWidthOnSelection = _outline.OutlineWidth;
            float timer = 0f;
            DOTween.To(() => timer, x => timer = x, 1, 0.25f)
                .OnUpdate(() =>
                {
                    _outline.OutlineWidth = Mathf.Lerp(outlineWidthOnSelection, OutlineMaxWidth, timer);
                });
        }

        public void Deselect()
        {
            float outlineWidthOnDeselection = _outline.OutlineWidth;
            float timer = 0f;
            DOTween.To(() => timer, x => timer = x, 1, 0.25f)
                .OnUpdate(() =>
                {
                    _outline.OutlineWidth = Mathf.Lerp(outlineWidthOnDeselection, 0, timer);
                });
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}