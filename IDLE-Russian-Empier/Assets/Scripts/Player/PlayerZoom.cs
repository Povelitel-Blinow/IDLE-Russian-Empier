using UnityEngine;

namespace PlayerCapsule
{
    public class PlayerZoom : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Camera _UICamera;
        [SerializeField] private float _zoomSensitivity;
        [SerializeField] private float _zoomingSpeed;
        [SerializeField] private Vector2Int _zoomBorders;

        private float _targetSize;

        public static PlayerZoom Instance { get; private set; }

        public float GameScale => _targetSize / _zoomBorders.y;

        public void Init()
        {
            _targetSize = _camera.orthographicSize;

            if(Instance == null)
            {
                Instance = this;
                return;
            }
            Destroy(gameObject);
        }

        public void Zoom()
        {
            _camera.orthographicSize += (_targetSize - _camera.orthographicSize) * _zoomingSpeed * Time.deltaTime;
            // rewrite
            _UICamera.orthographicSize = _camera.orthographicSize;
        }

        public void SetTargetZoom(float dir)
        {
            float newSize = _targetSize + dir * _zoomSensitivity * Time.deltaTime;
            _targetSize = Mathf.Clamp(newSize, _zoomBorders.x, _zoomBorders.y);
        }
    }
}