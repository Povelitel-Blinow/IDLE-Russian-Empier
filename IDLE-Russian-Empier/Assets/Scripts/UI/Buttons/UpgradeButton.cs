using UnityEngine;

namespace BuildingCapluse
{
    public class UpgradeButton : BuildingPanelButton
    {
        protected override void ClickAction() => _panel.UpgradeButtonClick();
    }
}