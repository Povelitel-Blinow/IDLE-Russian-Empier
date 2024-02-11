using UnityEngine;
using System;
using TMPro;

using UICapsule;
using BuildingCapluse;

public class UIManager : MonoBehaviour
{
    [SerializeField] private BuildingPanel _buildingPanelPrefab;
    [SerializeField] private BuildingInfoPanel _infoPanel;

    [Header("Text")] // I'll make an abstraction later
    [SerializeField] private TextMeshProUGUI _year;
    [SerializeField] private TextMeshProUGUI _money;
    [SerializeField] private TextMeshProUGUI _souls;

    private BuildingPanel _buildingPanel;

    public static UIManager Instance { get; private set; }

    public void Init(ref Action OnMove, ref Action OnZoom)
    {
        if (Instance != null) Destroy(gameObject);

        Instance = this;

        _buildingPanel = Instantiate(_buildingPanelPrefab);
        _buildingPanel.Init();

        OnMove += HideUI;
        OnZoom += AdaptUIScale;
    }

    private void HideUI()
    {
        _buildingPanel.Hide();
        _infoPanel.Hide();
    }

    private void AdaptUIScale()
    {
        _buildingPanel.AdaptScale();
    }

    public void NewYearButtonClickDebug()
    {
        Village.Instance.NewYear();
    }

    public void UpdateMoneyText(int money) => _money.text = money.ToString();

    public void UpdateSouls(int souls) => _souls.text = souls.ToString();

    public void UpdateYear(int year) => _year.text = year.ToString();

    public void UpdateUpgradeButtonImage() => _buildingPanel.UpdateUpgradeButtonImage();

    public void ShowBuildingPanel(BuildingPlace place) => _buildingPanel.Show(place);

    public void ShowInfoPanel(BuildingPlace place) => _infoPanel.Show(place);

    public enum UpgradeButtonState
    {
        CanUpgrade,
        CanNotUpgrade,
        MaxLevel
    }
}
