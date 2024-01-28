using UnityEngine;
using BuildingCapluse;

namespace PlayerCapsule
{
    public class PlayerInteract : MonoBehaviour
    {
        public void TryInteract()
        {
            Clickable requested = PlayerRaycast.RayCast<Clickable>();

            requested?.OnClick();
        }
    }
}