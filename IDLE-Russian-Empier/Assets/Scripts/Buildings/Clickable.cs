using UnityEngine;

namespace BuildingCapluse
{
    [RequireComponent(typeof(OutlineManager))]
    public abstract class Clickable : MonoBehaviour
    {
        public abstract void OnClick();
    }
}