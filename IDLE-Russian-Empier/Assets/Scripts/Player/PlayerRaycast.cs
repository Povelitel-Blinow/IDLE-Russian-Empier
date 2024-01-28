using UnityEngine;

namespace PlayerCapsule
{
    public static class PlayerRaycast
    {
        //Idk. Maybe it's better to use singletone pattern
        public static T RayCast<T>()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            Physics.Raycast(ray, out RaycastHit hit);

            hit.collider.TryGetComponent(out T required);

            return required;
        }
    }
}