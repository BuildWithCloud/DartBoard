namespace DartBoard;

public static class Frontend
{
    //outputs:
    public static void DisplayLeft (string message)
    {
        Console.WriteLine(message);
    }
    public static void DisplayRight (string message)
    {
        string output = new String(' ', Console.WindowWidth - message.Length);
        output += message;
        Console.WriteLine(output);
    }
    public static void DisplayLeftAndRight (string left, string right)
    {
        string output = left;
        output += new String(' ', (Console.WindowWidth - left.Length) - right.Length);
        output += right;
        Console.WriteLine(output);
    }
    
    //inputs:
    public static string? InputLeft(string message)
    {
        DisplayLeft(message);
        return Console.ReadLine();
    }
    public static string? InputRight(string message)
    {
        DisplayRight(message);
        Console.Write(new string(' ', Console.WindowWidth - message.Length));
        return Console.ReadLine();
    }
}