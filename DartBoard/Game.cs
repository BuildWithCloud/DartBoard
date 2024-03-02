namespace DartBoard;

public abstract class Game
{
    protected Player[] Players;
    protected int CurrentPlayer = 0;
    private bool _finished = false;
    protected int DisplayWidth;

    public void Play()
    {
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
    public void DefinePlayers()
    {
        for (int i = 0; i < Players.Length; i++)
        {
            Console.Write("Please enter the name of player" + i.ToString());
            string name = Console.ReadLine() ?? "";
            Players[i] = new Player(name);
        }
    }

    protected abstract Player? GameFinished();
    protected abstract void Display();
    protected abstract void EnterScore();
    protected abstract void DisplayWinner(Player winner);


}