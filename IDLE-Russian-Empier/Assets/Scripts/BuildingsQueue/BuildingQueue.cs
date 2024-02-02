using UnityEngine;

namespace BuildingCapluse
{
    [CreateAssetMenu]
    public class BuildingQueue : ScriptableObject
    {
        [SerializeField] private Building[] _queue;
        public Building[] BuildingsQueue => _queue;
    }
}
