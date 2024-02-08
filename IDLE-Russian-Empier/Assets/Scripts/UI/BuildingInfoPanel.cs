using BuildingCapluse;
using TMPro;
using UnityEngine;

namespace UICapsule
{
    public class BuildingInfoPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _infoText;

        public void Show(BuildingPlace buildingPlace)
        {
            _nameText.text = buildingPlace.Name;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _nameText.text = "";
            gameObject.SetActive(false);
        }
    }
}