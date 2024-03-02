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
            throw new NotImplementedException();
        }
    }
    protected override void EnterScore()
    {
        Throw t;
        if (CurrentPlayer == 0)
        {
            Console.WriteLine("Enter number:");
            int? scoreInt = null;
            while (scoreInt == null)
            {
                string score = Console.ReadLine() ?? " ";
                scoreInt = int.TryParse(score, out int result) ? result : null;
            }
            
            Console.WriteLine("Enter multiplier:");
            int? multiplierInt = null;
            while (multiplierInt == null)
            {
                string multiplier = Console.ReadLine() ?? " ";
                multiplierInt = int.TryParse(multiplier, out int result) ? result : null;
            }

            t = new Throw(multiplierInt.Value, scoreInt.Value);
        }
        else if (CurrentPlayer == 1)
        {
            Console.WriteLine(new string(' ', DisplayWidth - 13) + "Enter number:");
            int? scoreInt = null;
            while (scoreInt == null)
            {
                Console.Write(new string(' ', DisplayWidth - 2));
                string score = Console.ReadLine() ?? " ";
                scoreInt = int.TryParse(score, out int result) ? result : null;
            }
            
            Console.WriteLine(new string(' ', DisplayWidth - 16) + "Enter multiplier:");
            int? multiplierInt = null;
            while (multiplierInt == null)
            {
                Console.Write(new string(' ', DisplayWidth - 2));
                string multiplier = Console.ReadLine() ?? " ";
                multiplierInt = int.TryParse(multiplier, out int result) ? result : null;
            }

            t = new Throw(multiplierInt.Value, scoreInt.Value);
        }
        else
        {
            throw new NotImplementedException();
        }

        Players[CurrentPlayer].Throws.Add(t);        
    }
    protected override void DisplayWinner()
    {
        if (Players[0].Score <= DownFrom)
        {
            Console.WriteLine(Players[0].Name + " wins!");
        }
        else
        {
            Console.WriteLine(Players[1].Name + " wins!");
        }
    }
    
}
