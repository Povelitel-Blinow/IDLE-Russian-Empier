using UnityEngine;

namespace PlayerCapsule
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerRaycast _raycast;
        [SerializeField] private PlayerInput _input;
        [SerializeField] private PlayerMove _move;
        [SerializeField] private PlayerZoom _zoom;
        [SerializeField] private CameraManager _cameraManager;
        [SerializeField] private PlayerInteract _interact;
        [SerializeField] private PlayerSelect _select;

        public void Init()
        {
            _cameraManager.Init(transform);
            _raycast.Init(_cameraManager.MainCamera);
            _zoom.Init();
        }

        private void Update()
        {
            _move.Move(_input.GetMoveInput());
            _zoom.SetTargetZoom(_input.GetScroll());

            _cameraManager.MoveCameraToPlayer();
            _zoom.Zoom();

            _select.TrySelect();

            if (_input.GetClick())
                _interact.TryInteract();
        }
    }
}