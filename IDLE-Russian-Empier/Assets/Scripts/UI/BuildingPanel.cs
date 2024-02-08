using UnityEngine;
using DG.Tweening;
using PlayerCapsule;
using System;

namespace BuildingCapluse
{
    public class BuildingPanel : MonoBehaviour
    {
        [SerializeField] private float _adaptToScaleTime;

        private BuildingPlace _currentBuildingPlace;

        public static BuildingPanel Instance { get; private set; }

        public void Init()
        {
            if (Instance != null) Destroy(gameObject);

            Instance = this;

            gameObject.SetActive(false);           
        }

        public void Show(BuildingPlace buildingPlace)
        {
            NullLastPlace();

            _currentBuildingPlace = buildingPlace;

            buildingPlace.NotRaycastTarget();

            float scale = PlayerZoom.Instance.GameScale;
            transform.localScale = new Vector3(scale, scale, scale);

            transform.position = buildingPlace.transform.position;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);

            NullLastPlace();
        }

        private void NullLastPlace()
        {
            if (_currentBuildingPlace == null) return;

            _currentBuildingPlace.IsRaycastTarget();
            _currentBuildingPlace = null;
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

            //add changing sprites on the button 
            _currentBuildingPlace.Upgrade();
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}