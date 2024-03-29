namespace DartBoard;

public class ScoreDown : Game
{
    private int _downFrom;
    private const int ThrowsPerTurn = 3;
    
    public ScoreDown(int numOfPlayers)
    {
        Players = new Player[numOfPlayers];
    }
    protected override Player? GameFinished()
    {
        foreach (var t in Players)
        {
            if(t.Score >= _downFrom)
            {
                if(t.Turns[^1].Throws[^1].Multiplier == 2)
                {
                    return t;
                }
                
                t.Turns.RemoveAt(t.Turns.Count - 1);
            }
        }

        return null;
    }
    protected override void Display()
    {
        if (Players.Length == 2)
        {
            Console.Clear();
            Frontend.DisplayLeftAndRight(Players[0].Name, Players[1].Name);
            Frontend.DisplayLeftAndRight((_downFrom - Players[0].Score).ToString(), (_downFrom - Players[1].Score).ToString());
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
            int? scoreInt = null;
            int? multiplierInt = null;
            
            DisplayDependantOnPlayer("Enter number: ", CurrentPlayer);
            while (scoreInt == null)
            {
                var score = InputDependantOnPlayer(CurrentPlayer) ?? " ";
                if(score == "m")
                {
                    scoreInt = 0;
                    multiplierInt = 0;
                }
                else
                {
                    scoreInt = int.TryParse(score, out var result) ? result : null;
                    if (scoreInt is > 25 or < 1)
                    {
                        scoreInt = null;
                    } 
                }
            }
        
            DisplayDependantOnPlayer("Enter multiplier: ", CurrentPlayer);
            while (multiplierInt == null)
            {
                
                string multiplier = InputDependantOnPlayer(CurrentPlayer) ?? " ";
                multiplierInt = int.TryParse(multiplier, out int result) ? result : null;
                if (multiplierInt is > 3 or < 1)
                {
                    multiplierInt = null;
                }
            }
        
            throws[i] = new Throw(multiplierInt.Value, scoreInt.Value);
            
            
            
            Throw[] throwsSoFar = throws.Take(i+1).ToArray();
            //check if the player has won
            if (Players[CurrentPlayer].Score + throwsSoFar.Sum(t => t.Score) == _downFrom)
            {
                if (throws[i].Multiplier == 2)
                {
                    Players[CurrentPlayer].Turns.Add(new Turn(throwsSoFar));
                    return;
                }
                else
                {
                    Console.WriteLine("You must finish on a double");
                    return;
                }
            }
            else if (Players[CurrentPlayer].Score + throws[i].Score == 1)
            {
                Console.WriteLine("You cannot have 1");
                return;
            }
            else if (Players[CurrentPlayer].Score + throws[i].Score > _downFrom)
            {
                Console.WriteLine("You have gone over the target");
                return;
            }

            Display();
        }
        
        Players[CurrentPlayer].Turns.Add(new Turn(throws));
            
    }
    protected override void DisplayWinner(Player winner)
    {
        Frontend.DisplayLeft(winner.Name + " wins!");
        
    }
    protected override void DefineOptions()
    {
        
        Frontend.DisplayLeft("Please enter the score to play down from: ");
        int? downFrom = null;
        while (downFrom == null)
        {
            downFrom = int.TryParse(Frontend.InputLeft()?? " ", out int result) ? result : null;
        }

        _downFrom = (int)downFrom;
    }
    private void DisplayDependantOnPlayer(string message, int player)
    {
        if (player == 0)
        {
            Frontend.DisplayLeft(message);
        }
        else if (player == 1)
        {
            Frontend.DisplayRight(message);
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    private string? InputDependantOnPlayer(int player)
    {
        if (player == 0)
        {
            return Frontend.InputLeft();
        }
        else if (player == 1)
        {
            return Frontend.InputRight();
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}
