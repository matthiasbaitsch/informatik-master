
public class Board
{
    public const int W = 10;
    public const int H = 20;

    private readonly List<ConsoleColor?[]> colors = new List<ConsoleColor?[]>();

    public Board()
    {
        for (int i = 0; i < Board.H; i++)
        {
            this.colors.Add(new ConsoleColor?[Board.W]);
        }


    }

    public void Draw()
    {
        Console.Clear();
        Console.SetCursorPosition(3, 3);

        Console.Write("┌");
        for (int c = 0; c < W; c++) Console.Write("──");
        Console.WriteLine("┐   ");

        Console.
        Console.SetCursorPosition(5, 3);
        Console.Write("x");

    }

}