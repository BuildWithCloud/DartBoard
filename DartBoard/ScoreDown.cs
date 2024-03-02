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

    protected override Player GameFinished()
    {
        for(int i = 0; i < Players.Length; i++)
        {
            if(Players[i].Score >= DownFrom)
            {
                if(Players[i].Throws[^1].Multiplier == 2)
                {
                    return Players[i];
                }

                for (int j = 0; j < 3; j++)
                {
                    Players[i].Throws.RemoveAt(Players[i].Throws.Count - 1);
                }
            }
        }

        return null;
    }
    protected override void Display()
    {
        if (Players.Length == 2)
        {
            Console.Clear();
            {
                int numOfSpaces = DisplayWidth - Players[0].Name.Length +
                                  Players[1].Name.Length;
                string output = "";
                output += Players[0].Name;
                output += new String (' ', numOfSpaces);
                

                output += Players[1].Name;
                Console.WriteLine(output);
            }
            
            {
                int numOfSpaces = DisplayWidth - (DownFrom - Players[0].Score).ToString().Length +
                                  (DownFrom - Players[1].Score).ToString().Length;
                string output = "";
                output += (DownFrom - Players[0].Score).ToString();
                output += new String (' ', numOfSpaces);

                output += (DownFrom - Players[1].Score).ToString();
                Console.WriteLine(output);
            }

            
        }
        else
        {
            throw new NotImplementedException();
        }
    }
    protected override void EnterScore()
    {
        for (int i = 0; i < 3; i++)
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
    }
    protected override void DisplayWinner(Player winner)
    {
        Console.WriteLine(winner.Name + " wins!");
        
    }
    
}
