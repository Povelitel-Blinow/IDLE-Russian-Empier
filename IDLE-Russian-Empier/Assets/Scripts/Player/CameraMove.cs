using UnityEngine;

namespace PlayerCapsule
{
    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Transform _player;

        public void Init(Transform player)
        {
            _player = player;
        }

        public void MoveToPlayer()
        {
            transform.position += (_player.transform.position - transform.position) * _speed * Time.deltaTime;
        }
    }
}