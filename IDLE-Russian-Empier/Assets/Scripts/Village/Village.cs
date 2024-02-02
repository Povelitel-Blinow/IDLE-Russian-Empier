using BuildingCapluse;
using UnityEngine;

public class Village : MonoBehaviour
{
    [SerializeField] private BuildingPlacesInitiator _placesInitiator;

    [SerializeField] private int _startMoney;
    [SerializeField] private int _startSouls;

    [SerializeField] private Years _years;

    private Souls _souls;
    private Economics _economics;

    public int Souls => _souls.CurrentSouls;
    public int Money => _economics.Money;

    public int Year => _years.Year;

    public static Village Instance { get; private set; }

    public void Init()
    {
        if (Instance != null) Destroy(gameObject);

        Instance = this;

        _souls = new Souls(_years, _startSouls);
        _economics = new Economics(_souls, _startMoney);

        _placesInitiator.Init();
    }

    public void NewYear() 
    {
        _years.NewYear();

        _souls.NewYear();
        _economics.NewYear();
    }
}
