namespace DartBoard;

public abstract class Game
{
    protected Player[] Players;
    protected int CurrentPlayer = 0;
    private bool _finished = false;
    protected int DisplayWidth;


    public void DefinePlayers()
    {
        for (int i = 0; i < Players.Length; i++)
        {
            Console.Write("Please enter the name of player" + i.ToString());
            string name = Console.ReadLine() ?? "";
            Players[i] = new Player(name);
        }
    }

    public void Play()
    {
        while (!_finished)
        {
            Display();
            EnterInfo();
            _finished = GameFinished();
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

    protected abstract bool GameFinished();
    protected abstract void Display();
    protected abstract void EnterInfo();
    protected abstract void DisplayWinner();


}