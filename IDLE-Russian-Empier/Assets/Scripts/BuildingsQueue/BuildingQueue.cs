using UnityEngine;

namespace BuildingCapluse
{
    [CreateAssetMenu]
    public class BuildingQueue : ScriptableObject
    {
        [SerializeField] private Building[] _queue;

        private int _buildingIndex = 0;

        public bool CanUpgrade => _queue.Length > _buildingIndex;

        public Building GetNextBuilding()
        {
            if(_buildingIndex >= _queue.Length) return null;

            Building toReturn = _queue[_buildingIndex];
            _buildingIndex++;

            return toReturn;
        }
    }
}
