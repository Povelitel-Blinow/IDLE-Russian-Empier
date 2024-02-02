using UnityEngine;

namespace BuildingCapluse
{
    public class BuildingPlace : MonoBehaviour
    {
        [SerializeField] private BuildingQueue _queue;

        private int _buildingIndex = 0;

        private Building _currentBuilding;

        public Building CurrentBuilding => _currentBuilding;

        public void Init() => BuildHere();

        public void Upgrade()
        {
            //rewrite
            if (_buildingIndex >= _queue.BuildingsQueue.Length) return;

            _currentBuilding.UnBuild();
            _currentBuilding = null;
            BuildHere();
        }
        
        private void BuildHere()
        {
            _currentBuilding = Instantiate(_queue.BuildingsQueue[_buildingIndex]);
            _currentBuilding.Build(transform, this);
            _buildingIndex++;
        }
    }
}