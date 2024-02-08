using UnityEngine;

namespace BuildingCapluse
{
    [RequireComponent(typeof(MeshCollider))]
    [RequireComponent(typeof(OutlineManager))]

    public class BuildingClickable : Clickable
    {
        private Building _building;
        private MeshCollider _meshCollider;

        public void Init(Building building)
        {
            _building = building;
            _meshCollider = GetComponent<MeshCollider>();
        }

        public override void Click() => _building.SetPanel();

        public void SetIsRaycastTerget(bool state)
        {
            _meshCollider.enabled = state;
        }
    }
}
