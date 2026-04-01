namespace OOTetris;

public class Board
{
    public const int W = 10;
    public const int H = 20;
    private List<ConsoleColor?[]> colors = [];
    public Piece Piece = Piece.RandomPiece();

    public Board()
    {
        this.Fill();
    }

    private int Fill()
    {
        int c = 0;
        while (this.colors.Count < Board.H)
        {
            this.colors.Insert(0, new ConsoleColor?[Board.W]);
            c++;
        }
        return c;
    }

    private ConsoleColor ColorAt(int r, int c)
    {
        return this.Piece.Occupies(r, c) ? this.Piece.Color : this.colors[r][c] ?? ConsoleColor.Black;
    }

    public bool PieceFitsWithOffset(int dr, int dc)
    {
        foreach (var b in this.Piece.Bricks)
        {
            int r = this.Piece.Row + b[0] + dr;
            int c = this.Piece.Column + b[1] + dc;

            if (r < 0 || r >= Board.H)
            {
                return false;
            }
            if (c < 0 || c >= Board.W)
            {
                return false;
            }
            if (this.colors[r][c] != null)
            {
                return false;
            }
        }
        return true;
    }

    public bool TryMove(int dr, int dc)
    {
        if (this.PieceFitsWithOffset(dr, dc))
        {
            this.Piece.Move(dr, dc);
            return true;
        }
        return false;
    }

    public bool TryRotate()
    {
        this.Piece.Rotate(1);
        if (this.PieceFitsWithOffset(0, 0)) return true;
        if (this.TryMove(0, -1)) return true;
        if (this.TryMove(0, 1)) return true;
        this.Piece.Rotate(-1);
        return false;
    }

    public void Draw()
    {
        // CConsole.Clear();
        Console.SetCursorPosition(0, 0);
        CConsole.WriteLine("┌" + new string('─', 2 * W) + "┐   ");

        for (int r = 0; r < H; r++)
        {
            CConsole.Write("│");
            for (int c = 0; c < W; c++)
            {
                CConsole.Write(this.ColorAt(r, c), "██");
            }
            CConsole.WriteLine("│");
        }

        CConsole.WriteLine("└" + new string('─', 2 * W) + "┘   ");
    }

    public void Place()
    {
        foreach (var b in this.Piece.Bricks)
        {
            this.colors[this.Piece.Row + b[0]][this.Piece.Column + b[1]] = this.Piece.Color;
        }
    }

    public int ClearRows()
    {
        this.colors = [.. this.colors.Where(row => row.Count(x => x != null) < Board.W)];
        return this.Fill();
    }

}