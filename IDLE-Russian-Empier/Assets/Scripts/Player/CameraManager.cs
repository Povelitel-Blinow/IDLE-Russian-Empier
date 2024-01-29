using UnityEngine;

namespace PlayerCapsule
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        [SerializeField] private float _speed;

        private Transform _player;

        public Camera MainCamera => _camera;

        public void Init(Transform player)
        {
            _player = player;
        }

        public void MoveCameraToPlayer()
        {
            transform.position += (_player.transform.position - transform.position) * _speed * Time.deltaTime;
        }
    }
}