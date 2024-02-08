using UnityEngine;
using DG.Tweening;

namespace BuildingCapluse
{
    public class Building : MonoBehaviour
    {
        [SerializeField] private BuildingClickable _clickable;
        [SerializeField] private string _name = "";

        [SerializeField] private float _constructingTime = 1;

        private BuildingPlace _origin;

        public string Name => _name;

        public void Build(Transform pos, BuildingPlace origin)
        {
            _origin = origin;

            Construct(pos);

            if (_clickable == null) Debug.LogError("Clickable is not assigned!");
            _clickable.Init(this);
        }

        private void Construct(Transform pos)
        {
            transform.parent = pos;
            transform.position = pos.position;
            transform.rotation = pos.rotation;

            transform.localScale = Vector3.zero;
            transform.DOScale(new Vector3(1, 1, 1), _constructingTime);
        }

        public void SetPanel() => _origin.SetPanel();

        public void NotRaycastTarget() => _clickable.SetIsRaycastTerget(false);

        public void IsRaycastTarget() => _clickable.SetIsRaycastTerget(true);

        public void UnBuild()
        {
            transform.DOScale(Vector3.zero, _constructingTime)
                .OnComplete(() => Destroy(gameObject));
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}