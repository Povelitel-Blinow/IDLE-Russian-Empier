using UnityEngine;
using BuildingCapluse;

namespace PlayerCapsule
{
    public class PlayerSelect : MonoBehaviour
    {
        private OutlineManager _currentSelectedObject;

        public void TrySelect()
        {
            OutlineManager outline = PlayerRaycast.RayCast<OutlineManager>();

            if (outline == _currentSelectedObject) return;

            _currentSelectedObject?.Deselect();

            if(outline == null) NullOutline();

            else if(outline != null) NotNullOutline(outline);
        }

        private void NotNullOutline(OutlineManager outline)
        {
            _currentSelectedObject = outline;
            _currentSelectedObject.Select();
        }

        private void NullOutline()
        {
            _currentSelectedObject = null;
        }
    }
}