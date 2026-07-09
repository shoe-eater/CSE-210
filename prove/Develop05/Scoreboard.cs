// Singleton class
class Scoreboard
{
    private int _score;
    private static Scoreboard _instance;

    private Scoreboard()
    {
        _score = 0;
        _instance = this;
    }

    public static Scoreboard GetInstance()
    {
        Scoreboard instance;

        if (_instance == null)
        {
            instance = new Scoreboard();
        }
        else
        {
            instance = _instance;
        }

        return instance;
    }

    public void AddScore(int add)
    {
        _score += add;
    }

    public void SetScore(int set)
    {
        _score = set;
    }

    public int GetScore()
    {
        return _score;
    }
}