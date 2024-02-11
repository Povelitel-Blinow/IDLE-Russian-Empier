using System;
using UnityEngine;

public class Souls
{
    private int _currentSouls;

    private Years _years;

    public Action<int> OnSoulsChanged;

    public Souls(Years years, int startSouls) 
    {
        _years = years;
        _currentSouls = startSouls;
    }

    public void NewYear()
    {
        Died();
        NewBorns();

        OnSoulsChanged?.Invoke(_currentSouls);
    }

    private void NewBorns()
    {
        _currentSouls += Mathf.CeilToInt(Mathf.FloorToInt(_currentSouls / 2) * 0.14f);
    }

    private void Died()
    {
        int yearRatio = _years.GetYearDifficulty();

        //Debug.Log($"Dif = {yearRatio}");
        _currentSouls -= Mathf.FloorToInt(Mathf.FloorToInt(_currentSouls / 20) * yearRatio);
    }

    public int GetCurrentSouls() => _currentSouls;
}
