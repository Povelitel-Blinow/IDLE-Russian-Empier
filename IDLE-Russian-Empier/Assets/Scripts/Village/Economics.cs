public class Economics
{
    private int _money;

    private Souls _souls;

    public int Money => _money;

    public Economics(Souls souls, int startMoney)
    {
        _souls = souls;
        _money = startMoney;
    }

    public void AddMoney(int additionMoney)
    {
        _money += additionMoney;
        _money = _money > 0 ? _money : 0;
    }

    public void NewYear()
    {

    }
}
