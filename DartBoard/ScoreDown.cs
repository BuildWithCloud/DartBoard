namespace DartBoard;

public class ScoreDown : Game
{
    int DownFrom;
    public ScoreDown(int numOfPlayers, int downFrom, int displayWidth)
    {
        DownFrom = downFrom;
        Players = new Player[numOfPlayers];
        DisplayWidth = displayWidth;
    }

    protected override bool GameFinished()
    {
        for(int i = 0; i < Players.Length; i++)
        {
            if(Players[i].Score <= DownFrom)
            {
                if(Players[i].Throws[^1].Multiplier == 2)
                {
                    return true;
                }
            }
        }

        return false;
    }

    protected override void Display()
    {
        if (Players.Length == 2)
        {
            Console.Clear();
            int numofSpaces = DisplayWidth - Players[0].Score.ToString().Length + Players[1].Score.ToString().Length;
            string output = "";
            output += Players[0].Score.ToString();
            for (int i = 0; i < numofSpaces; i++)
            {
                output += " ";
            }
            output += Players[1].Score.ToString();
            Console.WriteLine(output);
        }
        else
        {
            throw NotImplementedException();
        }
    }
}
