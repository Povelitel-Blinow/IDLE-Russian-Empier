using UnityEngine;

namespace PlayerCapsule
{
    public class PlayerRaycast : MonoBehaviour
    {
        private Camera _camera;

        public static PlayerRaycast Instance { get; private set; }

        public void Init(Camera camera)
        {
            if(Instance == null)
            {
                Instance = this;
                _camera = camera;
                return;
            }
            Destroy(gameObject);
        }

        public T RayCast<T>()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            Physics.Raycast(ray, out RaycastHit hit);

            hit.collider.TryGetComponent(out T required);

            return required;
        }
    }
}