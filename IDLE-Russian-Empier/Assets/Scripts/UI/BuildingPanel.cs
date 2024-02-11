using UnityEngine;
using DG.Tweening;
using PlayerCapsule;

namespace BuildingCapluse
{
    public class BuildingPanel : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private InfoButton _infoButton;
        [SerializeField] private UpgradeButton _upgradeButton;

        [Header("Settings")]
        [SerializeField] private float _adaptToScaleTime;

        private BuildingPlace _currentBuildingPlace;

        public void Init()
        {
            gameObject.SetActive(false);

            _upgradeButton.Init(this);
            _infoButton.Init(this);
        }

        public void Show(BuildingPlace buildingPlace)
        {
            NullLastPlace();

            _currentBuildingPlace = buildingPlace;

            buildingPlace.BecomeNotRaycastTarget();

            float scale = PlayerZoom.Instance.GameScale;
            transform.localScale = new Vector3(scale, scale, scale);

            transform.position = buildingPlace.transform.position;

            UpdateUpgradeButtonImage();
            gameObject.SetActive(true);
        }

        private void NullLastPlace()
        {
            if (_currentBuildingPlace == null) return;

            _currentBuildingPlace.BecomeIsRaycastTarget();
            _currentBuildingPlace = null;
        }

        public void Hide()
        {
            gameObject.SetActive(false);

            NullLastPlace();
        }

        public void AdaptScale()
        {
            float scale = PlayerZoom.Instance.GameScale;
            transform.DOScale(new Vector3(scale, scale, scale), _adaptToScaleTime);
        }

        public void InfoButtonClick() => UIManager.Instance.ShowInfoPanel(_currentBuildingPlace);

        public void UpgradeButtonClick()
        {
            if (_currentBuildingPlace == null) return;

            _currentBuildingPlace.Upgrade();
            UpdateUpgradeButtonImage();
        }

        public void UpdateUpgradeButtonImage()
        {
            //3 references, but can be 2
            if(_currentBuildingPlace == null) return;

            var state = _currentBuildingPlace.GetButtonState();
            _upgradeButton.UpdateState(state);
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    } 
}