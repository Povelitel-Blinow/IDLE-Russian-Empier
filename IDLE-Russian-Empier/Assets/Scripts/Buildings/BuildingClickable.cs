using UnityEngine;

namespace BuildingCapluse
{
    [RequireComponent(typeof(MeshCollider))]
    [RequireComponent(typeof(OutlineManager))]

    public class BuildingClickable : Clickable
    {
        private Building _building;

        public void Init(Building building)
        {
            _building = building;
        }

        public override void OnClick()
        {
            BuildingPanel.Instance.Show(_building.Origin);
        }
    }
}
