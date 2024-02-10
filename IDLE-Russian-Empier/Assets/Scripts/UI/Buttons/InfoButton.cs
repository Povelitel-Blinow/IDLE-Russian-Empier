using UnityEngine;

namespace BuildingCapluse
{
    public class InfoButton : BuildingPanelButton
    {
        protected override void ClickAction() => _panel.InfoButtonClick();
    }
}