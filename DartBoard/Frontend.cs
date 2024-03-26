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
    public static string? InputLeft()
    {
        return Console.ReadLine();
    }
    public static string? InputRight()
    {
        string input = "";
        char c = ' ';
        while (c != '\r')
        {
            c = Console.ReadKey(true).KeyChar;
            if (c != '\r')
            {
                input += c;
                Console.SetCursorPosition(0, Console.GetCursorPosition().Top-1);
                Console.Write(new string(' ',Console.WindowWidth - input.Length ));
                Console.Write(input);
            }
        }

        return input;
    }
    public static string? InputRight(int buffer)
    {
        Console.Write(new string(' ', Console.WindowWidth - buffer));
        return Console.ReadLine();
    }
    
}