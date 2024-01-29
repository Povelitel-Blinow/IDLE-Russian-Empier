using UnityEngine;

namespace BuildingCapluse
{
    public class Building : MonoBehaviour
    {
        private BuildingPlace _origin;

        [SerializeField] private BuildingClickable _clickable;

        public void Build(Transform pos, BuildingPlace origin)
        {
            _origin = origin;
            
            transform.parent = pos;
            transform.position = pos.position;
            transform.rotation = pos.rotation;

            if (_clickable == null) Debug.LogError("Clickable is not assigned!");
            _clickable.Init(this);
        }
        
        public void UnBuild() => Destroy(gameObject);
        public void Upgrade()
        {
            _origin.Upgrade();
        }
    }
}