namespace BuildingCapluse 
{
    public abstract class BuildingButton : Clickable
    {
        protected BuildingPanel _panel;

        public void Init(BuildingPanel panel)
        {
            _panel = panel;
        }
    }
}