using System;
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

        public Action OnMove;
        public Action OnZoom;

        public void Init()
        {
            _cameraManager.Init(transform);
            _raycast.Init(_cameraManager.MainCamera);
            _zoom.Init();

            _interact.OnMissClick += MissClickedOrMoved;
        }

        private void Update()
        {
            CheckMove();

            CheckZoom();

            _cameraManager.MoveCameraToPlayer();
            _zoom.Zoom();

            _select.TrySelect();

            if (_input.GetClick())
                _interact.TryInteract();
        }

        private void CheckMove()
        {
            Vector2 moveInput = _input.GetMoveInput();
            _move.Move(moveInput);
            if (moveInput != Vector2.zero) MissClickedOrMoved();
        }

        private void CheckZoom()
        {
            float scroll = _input.GetScroll();
            _zoom.SetTargetZoom(scroll);
            if (scroll != 0f) OnZoom?.Invoke();
        }

        private void MissClickedOrMoved() => OnMove?.Invoke();
    }
}