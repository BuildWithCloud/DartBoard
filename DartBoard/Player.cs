namespace DartBoard;

public class Player
{
    public string Name;
    public List<Throw> Throws;

    public int Score
    {
        get{ return Throws.Sum(x => x.Score);}
    }

    public Player(string name)
    {
        Name = name;
        Throws = new List<Throw>();
    }
}