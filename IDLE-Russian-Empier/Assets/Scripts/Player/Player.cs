using UnityEngine;

namespace PlayerCapsule
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerInput _input;
        [SerializeField] private PlayerMove _move;
        [SerializeField] private PlayerZoom _zoom;
        [SerializeField] private CameraMove _cameraMove;
        [SerializeField] private PlayerInteract _interact;
        [SerializeField] private PlayerSelect _select;

        public void Init()
        {
            _cameraMove.Init(transform);
            _zoom.Init();
        }

        private void Update()
        {
            _move.Move(_input.GetMoveInput());
            _zoom.SetTargetZoom(_input.GetScroll());

            _cameraMove.MoveToPlayer();
            _zoom.Zoom();

            _select.TrySelect();

            if (_input.GetClick())
                _interact.TryInteract();
        }
    }
}