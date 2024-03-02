namespace DartBoard;

public class Throw
{
    public int Number;
    public int Multiplier;
    public int Score 
    {
        get 
        {
            return Number * Multiplier;
        }
    }

    public Throw(int multiplier, int number)
    {
        Number = number;
        Multiplier = multiplier;
    }
}
