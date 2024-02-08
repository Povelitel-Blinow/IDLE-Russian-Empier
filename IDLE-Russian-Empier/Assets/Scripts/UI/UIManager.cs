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

    private Village _village;

    public static UIManager Instance { get; private set; }

    public void Init(ref Action OnMove, ref Action OnZoom, Village village)
    {
        if (Instance != null) Destroy(gameObject);

        Instance = this;

        _buildingPanel = Instantiate(_buildingPanelPrefab);
        _buildingPanel.Init();

        OnMove += HideUI;
        OnZoom += AdaptUIScale;

        _village = village;
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

    public void NewYear()
    {
        _village.NewYear();

        _money.text = _village.Money.ToString();

        _souls.text = _village.Souls.ToString();

        _year.text = _village.Year.ToString();
    }

    public void ShowBuildingPanel(BuildingPlace place) => _buildingPanel.Show(place);

    public void ShowInfoPanel(BuildingPlace place) => _infoPanel.Show(place);
}
