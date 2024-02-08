namespace BuildingCapluse
{
    public abstract class BuildingPanelButton : Clickable
    {
        protected BuildingPanel _panel;

        public void Init(BuildingPanel panel)
        {
            _panel = panel;
        }
    }
}