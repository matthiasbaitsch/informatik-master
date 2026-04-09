using System.Diagnostics.CodeAnalysis;

namespace OOTetris;

public class Board
{
    public const int Width = 10;
    public const int Height = 20;

    private Piece? piece = null;
    private List<ConsoleColor?[]> colors = [];

    public Board()
    {
        this.FillRows();
    }

    private ConsoleColor ColorAt(int row, int col)
    {
        if (this.HasPiece() && this.piece.Occupies(row, col))
        {
            return this.piece.Color;
        }
        else
        {
            return this.colors[row][col] ?? ConsoleColor.Black;
        }
    }

    public bool CanMovePiece(int drow, int dcol)
    {
        return this.HasPiece() && this.FitsAt(this.piece, this.piece.Row + drow, this.piece.Col + dcol);
    }

    public void MovePiece(int drow, int dcol)
    {
        this.piece!.Row += drow;
        this.piece!.Col += dcol;
    }

    public void TryMovePiece(int dr, int dc)
    {
        if (this.CanMovePiece(dr, dc))
        {
            this.MovePiece(dr, dc);
        }
    }

    public void TryRotatePiece()
    {
        if (this.HasPiece())
        {
            this.piece.Rotation++;
            if (this.Fits(this.piece))
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
    }

    public void Draw()
    {
        string line = "──".Repeat(Board.Width);

        CConsole.WriteLine(0, 0, "┌" + line + "┐   ");
        for (int r = 0; r < Height; r++)
        {
            CConsole.Write("│");
            for (int c = 0; c < Board.Width; c++)
            {
                CConsole.Write(this.ColorAt(r, c), "██");
            }
            CConsole.WriteLine("│");
        }
        CConsole.WriteLine("└" + line + "┘   ");
    }

    public void Place()
    {
        foreach (int[] b in this.piece!.Bricks)
        {
            this.colors[this.piece.Row + b[0]][this.piece.Col + b[1]] = this.piece.Color;
        }
        this.piece = null;
    }

    public int ClearRows()
    {
        this.colors = [.. this.colors.Where(row => row.Count(x => x is not null) < Board.Width)];
        return this.FillRows();
    }

    public void TryPutPiece(Piece piece)
    {
        piece.Row = 0;
        piece.Col = Board.Width / 2 - 1;

        if (this.Fits(piece))
        {
            this.piece = piece;
        }
    }

    [MemberNotNullWhen(true, nameof(piece))]
    public bool HasPiece()
    {
        return this.piece is not null;
    }

    public void ClearLastLine()
    {
        this.colors = this.colors[..^1];
        this.FillRows();
    }

    private bool FitsAt(Piece p, int row, int col)
    {
        foreach (int[] b in p.Bricks)
        {
            int brow = row + b[0];
            int bcol = col + b[1];

            // If piece would move out of board
            if (brow < 0 || brow >= Board.Height || bcol < 0 || bcol >= Board.Width)
            {
                return false;
            }

            // If cell is occupied
            if (this.colors[brow][bcol] is not null)
            {
                return false;
            }
        }
        return true;
    }

    private bool Fits(Piece p)
    {
        return this.FitsAt(p, p.Row, p.Col);
    }

    private int FillRows()
    {
        int filled = 0;
        while (this.colors.Count < Board.Height)
        {
            this.colors.Insert(0, new ConsoleColor?[Board.Width]);
            filled++;
        }
        return filled;
    }
}