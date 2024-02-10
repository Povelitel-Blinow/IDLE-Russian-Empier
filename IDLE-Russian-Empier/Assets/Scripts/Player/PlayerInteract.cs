using UnityEngine;
using BuildingCapluse;
using System;

namespace PlayerCapsule
{
    public class PlayerInteract : MonoBehaviour
    {
        public Action OnMissClick;

        public void TryInteract()
        {
            Clickable requested = PlayerRaycast.Instance.RayCast<Clickable>();

            if (IsMissClick(requested)) return;
            requested.Click();
        }

        private bool IsMissClick(Clickable requested)
        {
            if (requested == null)
            {
                OnMissClick?.Invoke();
                return true;
            }
            return false;
        }
    }
}