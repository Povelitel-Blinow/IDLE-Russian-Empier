using UnityEngine;

namespace BuildingCapluse
{
    [RequireComponent(typeof(MeshCollider))]
    public class BuildingClickable : Clickable
    {
        private Building _building;

        public void Init(Building building)
        {
            _building = building;
        }

        public override void OnClick()
        {
            _building.Upgrade();
        }
    }
}
