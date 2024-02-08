namespace BuildingCapluse
{
    public class UpgradeButton : Clickable
    {
        public override void Click() => BuildingPanel.Instance.UpgradeButtonClick();
    }
}