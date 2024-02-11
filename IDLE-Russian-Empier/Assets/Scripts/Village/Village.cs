using BuildingCapluse;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Village : MonoBehaviour
{
    [SerializeField] private BuildingPlacesInitiator _placesInitiator;

    [SerializeField] private int _startMoney;
    [SerializeField] private int _startSouls;

    [SerializeField] private Years _years;

    private Souls _souls;
    private Economics _economics;

    public static Village Instance { get; private set; }

    public void Init()
    {
        if (Instance != null) Destroy(gameObject);

        Instance = this;

        _souls = new Souls(_years, _startSouls);
        _economics = new Economics(_souls, _startMoney);

        _placesInitiator.Init();

        _economics.OnChanged += UIManager.Instance.UpdateUpgradeButtonImage;

        _years.OnYearChanged += UIManager.Instance.UpdateYear;
        _souls.OnSoulsChanged += UIManager.Instance.UpdateSouls;
        _economics.OnMoneyChanged += UIManager.Instance.UpdateMoneyText;

        NewYear();
    }

    public bool TryUpgrade(Building building)
    {
       if(CheckCanUpgrade(building) == false) return false;

        _economics.AddMoney(-building.UpgradePrice);
        return true;
    }

    public bool CheckCanUpgrade(Building building)
    {
        if (_economics.Money < building.UpgradePrice) return false;

        return true;
    }

    public void NewYear() 
    {
        _years.NewYear();
        _souls.NewYear();
        _economics.NewYear();
    }
}
