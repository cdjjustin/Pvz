public class SunManager 
{
    public static SunManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SunManager();
            }
            return _instance;
        }
    }
        
    private static SunManager _instance;
        
    private int _totalSun = 0;
    public int TotalSun
    {
        get { return _totalSun; }
    }
        
    public void AddSun(int amount)
    {
        _totalSun += amount;
        UIManager.instance.UpdateSunCount();
    }
        
    public bool SpendSun(int amount)
    {
        if (_totalSun >= amount)
        {
            _totalSun -= amount;
            UIManager.instance.UpdateSunCount();
            return true;
        }
        return false;
    }
}