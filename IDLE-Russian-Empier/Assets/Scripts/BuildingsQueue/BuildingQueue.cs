using UnityEngine;

namespace BuildingCapluse
{
    [CreateAssetMenu]
    public class BuildingQueue : ScriptableObject
    {
        [SerializeField] private Building[] _queue;

        private int _buildingIndex = 0;

        public bool IsTheLastLevel => _queue.Length <= _buildingIndex;

        public Building GetNextBuilding()
        {
            if(IsTheLastLevel) return null;

            Building toReturn = _queue[_buildingIndex];
            _buildingIndex++;

            return toReturn;
        }
    }
}
