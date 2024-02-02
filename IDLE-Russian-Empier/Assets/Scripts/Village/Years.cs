using UnityEngine;

public class Years : MonoBehaviour
{
    [SerializeField] private YearWithEvents[] _events;

    [SerializeField] private YearDifficulty[] _difficulty;

    private int _currentYear = StartYear;

    public const int StartYear = 1775;

    public int Year => _currentYear;

    public void NewYear()
    {
        _currentYear += 1;
    }

    public int GetYearDifficulty()
    {
        foreach(YearDifficulty y in _difficulty)
        {
            if (y.Year == _currentYear)
                return (int)y.DifficultyRatio;
        }

        return (int)YearDifficulty.Difficulty.Common;
    }

    [System.Serializable]
    private struct YearDifficulty
    {
        public int Year;
        public Difficulty DifficultyRatio;

        public enum Difficulty
        {
            Common = 1,
            Hunger = 2,
            RecurringHunger = 3
        }
    }

    [System.Serializable]
    private struct YearWithEvents
    {
        public int YearOfEvent;

        public YearEvent[] Events;
    }
}
