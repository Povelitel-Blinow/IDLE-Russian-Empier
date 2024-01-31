using UnityEngine;

namespace BuildingCapluse
{
    public class UpgradeButton : BuildingButton
    {
        public override void OnClick() => _panel.UpgradeButtonClick();
    }
}