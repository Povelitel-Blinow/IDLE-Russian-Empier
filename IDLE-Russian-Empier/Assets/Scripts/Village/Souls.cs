using UnityEngine;

public class Souls
{
    private int _currentSouls;

    private Years _years;

    public int CurrentSouls => _currentSouls;

    public Souls(Years years, int startSouls) 
    {
        _years = years;
        _currentSouls = startSouls;
    }

    public void NewYear()
    {
        Died();
        NewBorns();
    }

    private void NewBorns()
    {
        _currentSouls += Mathf.CeilToInt(Mathf.FloorToInt(_currentSouls / 2) * 0.14f);
    }

    private void Died()
    {
        int yearRatio = _years.GetYearDifficulty();

        Debug.Log($"Dif = {yearRatio}");
        _currentSouls -= Mathf.FloorToInt(Mathf.FloorToInt(_currentSouls / 20) * yearRatio);
    }
}
