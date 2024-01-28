using UnityEngine;

namespace PlayerCapsule
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        public void Move(Vector2 input)
        {
            input = input.normalized * _moveSpeed * Time.deltaTime;

            float newX = input.x + transform.position.x;
            float newZ = input.y + transform.position.z;

            transform.position = new Vector3(newX, transform.position.y, newZ);
        }
    }
}