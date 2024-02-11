using UnityEngine;

namespace BuildingCapluse
{
    public class UpgradeButton : BuildingPanelButton
    {
        [SerializeField] private SpriteRenderer _renderer;

        [Header("Button State Sprites")]
        [SerializeField] private Sprite _canUpgrade; 
        [SerializeField] private Sprite _canNotUpgrade; 
        [SerializeField] private Sprite _maxLevel; 

        public void UpdateState(UIManager.UpgradeButtonState state)
        {
            switch (state)
            {
                case UIManager.UpgradeButtonState.CanUpgrade:
                    _renderer.sprite = _canUpgrade;
                    break;

                case UIManager.UpgradeButtonState.MaxLevel:
                    _renderer.sprite = _maxLevel;
                    break;

                default:
                    _renderer.sprite = _canNotUpgrade; 
                    break;
            }
        }

        protected override void ClickAction() => _panel.UpgradeButtonClick();
    }
}