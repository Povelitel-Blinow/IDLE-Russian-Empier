using UnityEngine;

namespace BuildingCapluse
{
    public class Building : MonoBehaviour
    {
        [SerializeField] private BuildingClickable _clickable;
        [SerializeField] private string _name = "";

        private BuildingPlace _origin;

        public string Name => _name;
        public BuildingPlace Origin => _origin;

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
    }
}