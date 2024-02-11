using UnityEngine;
using BuildingCapluse;

namespace PlayerCapsule
{
    public class PlayerSelect : MonoBehaviour
    {
        private OutlineManager _currentSelectedObject;
        private BuildingPanelButton _currentButton;

        public void TrySelect()
        {
            TrySelectOutline();
            TrySelectButton();
        }
        
        private void TrySelectButton()
        {
            BuildingPanelButton button = PlayerRaycast.Instance.RayCast<BuildingPanelButton>();

            if (button == null) 
            {
                NullButton();
                return;
            }

            if (button == _currentButton) return;

            _currentButton = button;
            _currentButton.Select();

            void NullButton()
            {
                if (_currentButton == null) return;

                _currentButton.Deselect();
                _currentButton = null;
            }
        }

        private void TrySelectOutline()
        {
            OutlineManager outline = PlayerRaycast.Instance.RayCast<OutlineManager>();

            if (outline == _currentSelectedObject) return;

            _currentSelectedObject?.Deselect();

            if (outline == null) NullOutline();

            else if (outline != null) NotNullOutline(outline);

            void NotNullOutline(OutlineManager outline)
            {
                _currentSelectedObject = outline;
                _currentSelectedObject.Select();
            }

            void NullOutline()
            {
                _currentSelectedObject = null;
            }
        }
    }
}