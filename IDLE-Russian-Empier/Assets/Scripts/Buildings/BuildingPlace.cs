using UnityEngine;

namespace BuildingCapluse
{
    public class BuildingPlace : MonoBehaviour
    {
        [SerializeField] private BuildingQueue _queuePrefab;

        private BuildingQueue _buildingQueue;
        private Building _currentBuilding;

        public string Name => _currentBuilding.Name;

        public void Init()
        {
            _buildingQueue = Instantiate(_queuePrefab);
            BuildHere();
        }

        public void Upgrade()
        {
            if(_buildingQueue.CanUpgrade == false) return;

            _currentBuilding.UnBuild();
            _currentBuilding = null;
            BuildHere();
        }
        
        private void BuildHere()
        {
            _currentBuilding = Instantiate(_buildingQueue.GetNextBuilding());
            _currentBuilding.Build(transform, this);
        }

        public void SetPanel() => UIManager.Instance.ShowBuildingPanel(this);

        public void NotRaycastTarget() => _currentBuilding.NotRaycastTarget();

        public void IsRaycastTarget() => _currentBuilding.IsRaycastTarget();
    }
}