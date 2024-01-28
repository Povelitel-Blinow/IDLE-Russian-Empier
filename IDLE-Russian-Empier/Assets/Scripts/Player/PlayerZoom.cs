using UnityEngine;

namespace PlayerCapsule
{
    public class PlayerZoom : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _zoomSensitivity;
        [SerializeField] private float _zoomingSpeed;
        [SerializeField] private Vector2Int _zoomBorders;

        private float _targetSize;

        public void Init()
        {
            _targetSize = _camera.orthographicSize;
        }

        public void Zoom()
        {
            _camera.orthographicSize += (_targetSize - _camera.orthographicSize) * _zoomingSpeed * Time.deltaTime;
        }

        public void SetTargetZoom(float dir)
        {
            float newSize = _targetSize + dir * _zoomSensitivity * Time.deltaTime;
            _targetSize = Mathf.Clamp(newSize, _zoomBorders.x, _zoomBorders.y);
        }
    }
}