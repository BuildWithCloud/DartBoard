namespace DartBoard;

public abstract class Game
{
    private int MaxPlayers;
    private int MinPlayers;
    private Player[] Players;
    private int CurrentPlayer;
    private bool Finished;
    

    public Game()
    {
        Finished = false;
    }
    public void DefinePlayers()
    {
        for (int i = 0; i < Players.Length; i++)
        {
            Console.Write("Please enter the name of player" + i.ToString());
            string name = Console.ReadLine();
            Players[i] = new Player(name);
        }
    }

    public void Play()
    {
        while (!Finished)
        {
            Display();
            EnterInfo();
            Finished = GameFinished();
        }
    }
    public abstract bool GameFinished();
    public abstract void Display();
    public abstract void EnterInfo();
    
    
}