namespace DartBoard;

public class ScoreDown : Game
{
    private readonly int _downFrom;
    private const int ThrowsPerTurn = 3;

    public ScoreDown(int numOfPlayers, int downFrom, int displayWidth)
    {
        _downFrom = downFrom;
        Players = new Player[numOfPlayers];
        DisplayWidth = displayWidth;
    }
    
    public override void Play()
    {
        DefinePlayers();
        while (true)
        {
            Display();
            for (int i = 0; i < 3; i++)
            {
                EnterScore();
                if (GameFinished() != null)
                {
                    _finished = true;
                    DisplayWinner(Players[CurrentPlayer]);
                    break;
                }
            }
            
            
            if (!_finished)
            {
                CurrentPlayer++;
                if (CurrentPlayer == Players.Length)
                {
                    CurrentPlayer = 0;
                }
            }
        }
        
    }

    protected override Player GameFinished()
    {
        for(int i = 0; i < Players.Length; i++)
        {
            if(Players[i].Score >= _downFrom)
            {
                if(Players[i].Turns[^1].Throws[^1].Multiplier == 2)
                {
                    return Players[i];
                }
                
                Players[i].Turns.RemoveAt(Players[i].Turns.Count - 1);
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
                int numOfSpaces = DisplayWidth - (_downFrom - Players[0].Score).ToString().Length +
                                  (_downFrom - Players[1].Score).ToString().Length;
                string output = "";
                output += (_downFrom - Players[0].Score).ToString();
                output += new String (' ', numOfSpaces);

                output += (_downFrom - Players[1].Score).ToString();
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
        
        Throw[] throws = new Throw[ThrowsPerTurn];
        
        for(int i = 0; i < ThrowsPerTurn; i++)
        {
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
            
                throws[i] = new Throw(multiplierInt.Value, scoreInt.Value);
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
            
                throws[i] = new Throw(multiplierInt.Value, scoreInt.Value);
            }
            else
            {
                throw new NotImplementedException();
            }
            
        }
        
        Players[CurrentPlayer].Turns.Add(new Turn(throws));
            
    }
    protected override void DisplayWinner(Player winner)
    {
        Console.WriteLine(winner.Name + " wins!");
        
    }
    
}
