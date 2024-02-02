using UnityEngine;

namespace BuildingCapluse
{
    public class BuildingPlacesInitiator : MonoBehaviour
    {
        [SerializeField] private BuildingPlace[] _places;

        public void Init()
        {
            foreach (BuildingPlace place in _places)
            {
                place.Init();
            }
        }
    }
}
