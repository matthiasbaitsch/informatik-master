using System.Diagnostics;

namespace OOTetris;

public class Piece
{

    public enum Type
    {
        I, O, T, S, Z, J, L
    }

    public static Piece MakePiece(Type t)
    {
        switch (t)
        {
            case Type.I:
                return new Piece(
                    ConsoleColor.Red,
                    [
                        [[0,0],[0,1],[0,2],[0,3]],
                        [[0,0],[1,0],[2,0],[3,0]]
                    ]
                );
            case Type.O:
                return new Piece(
                    ConsoleColor.Blue,
                    [
                        [[0,0],[0,1],[1,0],[1,1]]
                    ]
                );
            case Type.T:
                return new Piece(
                    ConsoleColor.Green,
                    [
                        [[0,1],[1,0],[1,1],[1,2]],
                        [[0,0],[1,0],[1,1],[2,0]],
                        [[0,0],[0,1],[0,2],[1,1]],
                        [[0,1],[1,0],[1,1],[2,1]]
                    ]
                );
            case Type.S:
                return new Piece(
                    ConsoleColor.Cyan,
                    [
                        [[0,1],[0,2],[1,0],[1,1]],
                        [[0,0],[1,0],[1,1],[2,1]]
                    ]
                );
            case Type.Z:
                return new Piece(
                    ConsoleColor.Magenta,
                    [
                        [[0,0],[0,1],[1,1],[1,2]],
                        [[0,1],[1,0],[1,1],[2,0]]
                    ]
                );
            case Type.J:
                return new Piece(
                    ConsoleColor.DarkMagenta,
                    [
                        [[0,0],[1,0],[1,1],[1,2]],
                        [[0,0],[0,1],[1,0],[2,0]],
                        [[0,0],[0,1],[0,2],[1,2]],
                        [[0,1],[1,1],[2,0],[2,1]]
                    ]
                );
            case Type.L:
                return new Piece(
                    ConsoleColor.Yellow,
                    [
                        [[0,2],[1,0],[1,1],[1,2]],
                        [[0,0],[1,0],[2,0],[2,1]],
                        [[0,0],[0,1],[0,2],[1,0]],
                        [[0,0],[0,1],[1,1],[2,1]]
                    ]
                );
        }
        throw new UnreachableException();
    }

    public static Piece RandomPiece()
    {
        var values = Enum.GetValues<Type>();
        return MakePiece(values[Random.Shared.Next(values.Length)]);
    }

    public readonly ConsoleColor Color;
    public readonly int[][][] AllBricks;
    public int Row { get; private set; }
    public int Column { get; private set; }
    public int Rotation
    {
        get; set
        {
            int n = this.AllBricks.Length;
            field = (value % n + n) % n;
        }
    }

    public int[][] Bricks
    {
        get
        {
            return this.AllBricks[this.Rotation];
        }
    }

    public Piece(ConsoleColor c, int[][][] b)
    {
        this.Color = c;
        this.AllBricks = b;
        this.Row = 0;
        this.Column = 0;
        this.Rotation = 0;
    }

    public void Move(int dr, int dc)
    {
        this.Row += dr;
        this.Column += dc;
    }

    public bool Occupies(int r, int c)
    {
        foreach (var p in this.Bricks)
        {
            if (this.Row + p[0] == r && this.Column + p[1] == c)
            {
                return true;
            }
        }
        return false;
    }
}