namespace DartBoard;

public abstract class Game
{
    protected Player[] Players;
    protected int CurrentPlayer = 0;
    private bool _finished = false;
    
    
    public virtual void Play()
    {
        DefineOptions();
        DefinePlayers();
        while (true)
        {
            Display();
            EnterScore();
            if (GameFinished() != null)
            {
                _finished = true;
                DisplayWinner(Players[CurrentPlayer]);
                break;
            }

            if (_finished) continue;
            CurrentPlayer++;
            if (CurrentPlayer == Players.Length)
            {
                CurrentPlayer = 0;
            }
        }
        
    }
    private void DefinePlayers()
    {
        for (var i = 0; i < Players.Length; i++)
        {
            Console.Write("Please enter the name of player " + i.ToString() + ": ");
            var name = Console.ReadLine() ?? "";
            Players[i] = new Player(name);
        }
    }
    protected abstract void DefineOptions();
    protected abstract Player? GameFinished();
    protected abstract void Display();
    protected abstract void EnterScore();
    protected abstract void DisplayWinner(Player winner);


}