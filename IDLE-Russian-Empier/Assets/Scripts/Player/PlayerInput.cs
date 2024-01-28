using UnityEngine;

namespace PlayerCapsule
{
    public class PlayerInput : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";

        public Vector2 GetMoveInput()
        {
            Vector2 moveDir = Vector2.zero;
            moveDir.x = Input.GetAxisRaw(Horizontal);
            moveDir.y = Input.GetAxisRaw(Vertical);
            return moveDir;
        }

        public float GetScroll()
        {
            return -Input.mouseScrollDelta.y;
        }

        // I could've made an event...
        public bool GetClick() => Input.GetMouseButtonDown(0);
    }
}