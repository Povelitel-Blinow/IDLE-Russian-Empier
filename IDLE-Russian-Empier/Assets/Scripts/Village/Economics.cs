using System;

public class Economics
{
    private int _money;

    private Souls _souls;

    public int Money => _money;

    public Action OnChanged;
    public Action<int> OnMoneyChanged;

    public Economics(Souls souls, int startMoney)
    {
        _souls = souls;
        _money = startMoney;
    }

    public void NewYear()
    {
        AddMoney(_souls.GetCurrentSouls() * 10);
    }
    public void AddMoney(int additionMoney)
    {
        _money += additionMoney;
        _money = _money > 0 ? _money : 0;

        OnMoneyChanged?.Invoke(_money);
        OnChanged?.Invoke();
    }
}
