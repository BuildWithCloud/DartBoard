namespace DartBoard;

public class Player
{
    public string Name;
    public List<Turn> Turns;

    public int Score
    {
        get{ return Turns.Sum(x => x.Score);}
    }

    public Player(string name)
    {
        Name = name;
        Turns = new List<Turn>();
    }
}