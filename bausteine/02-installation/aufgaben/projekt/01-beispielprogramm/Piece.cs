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
        if (t == Type.I)
        {
            return new Piece(
                ConsoleColor.Red,
                [
                    [[0,0],[0,1],[0,2],[0,3]],
                    [[0,0],[1,0],[2,0],[3,0]]
                ]
            );
        }
        else if (t == Type.O)
        {
            return new Piece(
                ConsoleColor.Blue,
                [
                    [[0,0],[0,1],[1,0],[1,1]]
                ]
            );
        }
        else if (t == Type.T)
        {
            return new Piece(
                ConsoleColor.Green,
                [
                    [[0,1],[1,0],[1,1],[1,2]],
                    [[0,0],[1,0],[1,1],[2,0]],
                    [[0,0],[0,1],[0,2],[1,1]],
                    [[0,1],[1,0],[1,1],[2,1]]
                ]
            );
        }
        else if (t == Type.S)
        {
            return new Piece(
                ConsoleColor.Cyan,
                [
                    [[0,1],[0,2],[1,0],[1,1]],
                    [[0,0],[1,0],[1,1],[2,1]]
                ]
            );
        }
        else if (t == Type.Z)
        {
            return new Piece(
                ConsoleColor.Magenta,
                [
                    [[0,0],[0,1],[1,1],[1,2]],
                    [[0,1],[1,0],[1,1],[2,0]]
                ]
            );
        }
        else if (t == Type.J)
        {
            return new Piece(
                ConsoleColor.DarkMagenta,
                [
                    [[0,0],[1,0],[1,1],[1,2]],
                    [[0,0],[0,1],[1,0],[2,0]],
                    [[0,0],[0,1],[0,2],[1,2]],
                    [[0,1],[1,1],[2,0],[2,1]]
                ]
            );
        }
        else if (t == Type.L)
        {
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
        else
        {
            throw new UnreachableException();
        }
    }

    public static Piece RandomPiece()
    {
        Piece.Type[] values = Enum.GetValues<Piece.Type>();
        return MakePiece(values[Random.Shared.Next(values.Length)]);
    }

    public int Row = 0;
    public int Col = 0;
    public readonly ConsoleColor Color;
    public readonly int[][][] AllBricks;

    public int Rotation
    {
        get; set
        {
            int n = this.AllBricks.Length;
            field = (value % n + n) % n;
        }
    } = 0;

    public int[][] Bricks
    {
        get
        {
            return this.AllBricks[this.Rotation];
        }
    }

    public Piece(ConsoleColor color, int[][][] allBricks)
    {
        this.Color = color;
        this.AllBricks = allBricks;
    }

    public bool Occupies(int row, int col)
    {
        foreach (int[] p in this.Bricks)
        {
            if (this.Row + p[0] == row && this.Col + p[1] == col)
            {
                return true;
            }
        }
        return false;
    }
}