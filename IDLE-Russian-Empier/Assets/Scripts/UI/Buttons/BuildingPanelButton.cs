using UnityEngine;

namespace BuildingCapluse
{
    public abstract class BuildingPanelButton : Clickable
    {
        protected BuildingPanel _panel;

        public void Init(BuildingPanel panel)
        {
            _panel = panel;
        }

        public void Select()
        {
            //Debug.Log("Button Selected");
        }

        public void Deselect()
        {
            //Debug.Log("Button Deselected");
        }

        public sealed override void Click()
        {
            //Debug.Log("Button Clicked");
            ClickAction();
        }

        protected abstract void ClickAction();
    }
}