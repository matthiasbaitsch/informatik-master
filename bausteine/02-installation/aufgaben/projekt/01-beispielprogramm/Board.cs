namespace OOTetris;

public class Board
{
    public const int Width = 10;
    public const int Height = 20;

    private Piece? piece = null;
    private List<ConsoleColor?[]> colors = [];

    public Board()
    {
        this.Fill();
    }

    private int Fill()
    {
        int filled = 0;
        while (this.colors.Count < Board.Height)
        {
            this.colors.Insert(0, new ConsoleColor?[Board.Width]);
            filled++;
        }
        return filled;
    }

    private ConsoleColor ColorAt(int r, int c)
    {
        if (this.piece != null && this.piece.Occupies(r, c))
        {
            return this.piece.Color;
        }
        else
        {
            return this.colors[r][c] ?? ConsoleColor.Black;
        }
    }

    public bool CanMovePiece(int dr, int dc)
    {
        // No Piece
        if (this.piece == null)
        {
            return false;
        }

        // Piece
        foreach (var b in this.piece.Bricks)
        {
            int row = this.piece.Row + b[0] + dr;
            int col = this.piece.Column + b[1] + dc;

            // If piece would move out of board
            if (row < 0 || row >= Board.Height || col < 0 || col >= Board.Width)
            {
                return false;
            }

            // If cell is occupied
            if (this.colors[row][col] != null)
            {
                return false;
            }
        }
        return true;
    }

    public void TryMovePiece(int dr, int dc)
    {
        if (this.CanMovePiece(dr, dc))
        {
            this.MovePiece(dr, dc);
        }
    }

    public void MovePiece(int dr, int dc)
    {
        this.piece!.Move(dr, dc);
    }

    public void TryRotatePiece()
    {
        if (this.piece == null)
        {
            return;
        }

        this.piece.Rotation++;
        if (this.CanMovePiece(0, 0))
        {
            return;
        }
        if (this.CanMovePiece(0, -1))
        {
            this.MovePiece(0, -1);
            return;
        }
        if (this.CanMovePiece(0, 1))
        {
            this.MovePiece(0, 1);
            return;
        }
        this.piece.Rotation--;
    }

    public void Draw()
    {
        string line = new('─', 2 * Width);
        CConsole.WriteLine(0, 0, "┌" + line + "┐   ");

        for (int r = 0; r < Height; r++)
        {
            CConsole.Write("│");
            for (int c = 0; c < Width; c++)
            {
                CConsole.Write(this.ColorAt(r, c), "██");
            }
            CConsole.WriteLine("│");
        }

        CConsole.WriteLine("└" + line + "┘   ");
    }

    public void Place()
    {
        foreach (var b in this.piece!.Bricks)
        {
            this.colors[this.piece.Row + b[0]][this.piece.Column + b[1]] = this.piece.Color;
        }
        this.piece = null;
    }

    public bool HasPiece()
    {
        return this.piece != null;
    }

    public int ClearRows()
    {
        this.colors = [.. this.colors.Where(row => row.Count(x => x != null) < Board.Width)];
        return this.Fill();
    }

    public void TryPutPiece(Piece piece)
    {
        this.piece = piece;
        this.piece.Move(0, Board.Width / 2 - 1);
        if (!this.CanMovePiece(0, 0))
        {
            this.piece = null;
        }
    }

}