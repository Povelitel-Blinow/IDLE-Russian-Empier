using TMPro;
using UnityEngine;

namespace UICansule
{
    public class BuildingUIPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _infoText;

        public void Show(string name)
        {
            _nameText.text = name;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            _nameText.text = "";
            gameObject.SetActive(false);
        }
    }
}