namespace DartBoard;

public class Turn
{
    public Throw[] Throws;

    public int Score
    {
        get{ return Throws.Sum(t => t.Score);}
    }
    
    public Turn(Throw[] throws)
    {
        Throws = throws;
    }
    
}