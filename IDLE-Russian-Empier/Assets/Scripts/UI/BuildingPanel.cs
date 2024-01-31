using DG.Tweening;
using PlayerCapsule;
using UnityEngine;

namespace BuildingCapluse
{
    public class BuildingPanel : MonoBehaviour
    {
        [SerializeField] private UpgradeButton _upgradeButton;
        [SerializeField] private InfoButton _infoButton;

        [SerializeField] private float _adaptToScaleTime;

        private BuildingPlace _currentBuildingPlace;

        public static BuildingPanel Instance { get; private set; }

        public void Init()
        {
            if (Instance == null)
            {
                Instance = this;
                gameObject.SetActive(false);

                _upgradeButton.Init(this);
                _infoButton.Init(this);
                return;
            }
            Destroy(gameObject);
        }

        public void Show(BuildingPlace buildingPlace)
        {
            _currentBuildingPlace = buildingPlace;

            float scale = PlayerZoom.Instance.GameScale;
            transform.localScale = new Vector3(scale, scale, scale);

            transform.position = buildingPlace.transform.position;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _currentBuildingPlace = null;
            gameObject.SetActive(false);
        }

        public void AdaptScale()
        {
            float scale = PlayerZoom.Instance.GameScale;
            transform.DOScale(new Vector3(scale, scale, scale), _adaptToScaleTime);
        }

        public void InfoButtonClick()
        {
            Debug.Log(1);
        }

        public void UpgradeButtonClick()
        {
            if (_currentBuildingPlace == null) return;

            //add changing sprites on the button 
            _currentBuildingPlace.Upgrade();
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}