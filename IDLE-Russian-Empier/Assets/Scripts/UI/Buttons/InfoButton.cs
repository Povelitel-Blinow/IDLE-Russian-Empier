namespace BuildingCapluse
{
    public class InfoButton : Clickable
    {
        public override void Click() => BuildingPanel.Instance.InfoButtonClick();
    }
}