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

        private void BuildHere()
        {
            _currentBuilding = Instantiate(_buildingQueue.GetNextBuilding());
            _currentBuilding.Build(transform, this);
        }

        public void Upgrade()
        {
            if(_buildingQueue.IsTheLastLevel) return;

            if(Village.Instance.TryUpgrade(_currentBuilding) == false) return;

            _currentBuilding.UnBuild();
            _currentBuilding = null;
            BuildHere();
        }

        public UIManager.UpgradeButtonState GetButtonState()
        {
            var state = UIManager.UpgradeButtonState.CanNotUpgrade;

            if (_buildingQueue.IsTheLastLevel)
                state = UIManager.UpgradeButtonState.MaxLevel;

            else if (Village.Instance.CheckCanUpgrade(_currentBuilding) == true)
                state = UIManager.UpgradeButtonState.CanUpgrade;

            return state;
        }

        public void SetPanel() => UIManager.Instance.ShowBuildingPanel(this);

        public void BecomeNotRaycastTarget() => _currentBuilding.NotRaycastTarget();

        public void BecomeIsRaycastTarget() => _currentBuilding.IsRaycastTarget();
    }
}