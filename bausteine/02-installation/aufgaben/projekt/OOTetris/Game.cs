namespace OOTetris;

class Game
{
    private static readonly int[] SCORES_FOR_ROWS = [0, 100, 300, 500, 800];

    private Board Board = new Board();
    private int DropInterval = 500;
    private DateTime LastGravity = DateTime.Now;
    private bool GameOver = false;
    private int Lines;
    private int Score;
    private Piece NextPiece = Piece.MakeRandomPiece();

    public void Play()
    {
        Console.CursorVisible = false;
        Console.Clear();
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        this.Spawn();
        this.Draw();

        while (!this.GameOver)
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Q) this.GameOver = true;
                else if (key == ConsoleKey.LeftArrow) this.Board.TryMove(0, -1);
                else if (key == ConsoleKey.RightArrow) this.Board.TryMove(0, 1);
                else if (key == ConsoleKey.DownArrow) this.Board.TryMove(1, 0);
                else if (key == ConsoleKey.UpArrow) this.Board.TryRotate();
                else if (key == ConsoleKey.Spacebar) while (this.Board.TryMove(1, 0)) { }
            }

            if (this.IsTimeForGravity())
            {
                this.Board.TryMove(1, 0);
                this.LastGravity = DateTime.Now;
            }

            if (!this.Board.PieceFitsWithOffset(1, 0))
            {
                this.Board.Place();
                this.UpdateScore(this.Board.ClearRows());
                this.Spawn();
            }

            this.GameOver = this.GameOver || !this.Board.PieceFitsWithOffset(0, 0);

            this.Draw();

            Thread.Sleep(16);
        }

        CConsole.WriteLine(23, 0, ConsoleColor.Red, "Game Over");
        CConsole.WriteLine(24, 0, "Drücke Enter...");
        Console.ReadLine();
    }

    private void Draw()
    {
        int c = 5 + 2 * Board.W;

        this.Board.Draw();

        foreach (var b in this.NextPiece.Bricks)
        {
            CConsole.Write(1 + b[0], c + 2 * b[1], this.NextPiece.Color, "██");
        }

        CConsole.Write(6, c, "Lines: " + this.Lines);
        CConsole.Write(7, c, "Level: " + this.Level);
        CConsole.Write(8, c, "Score: " + this.Score);
        CConsole.Write(16, c, " ← →  Bewegen");
        CConsole.Write(17, c, "  ↑   Drehen");
        CConsole.Write(18, c, "  ↓   Schneller");
        CConsole.Write(19, c, "Space Fallenlassen");
        CConsole.Write(20, c, "  q   Ende");
    }


    private void UpdateScore(int cleared)
    {
        this.Score += this.Level * Game.SCORES_FOR_ROWS[cleared];
        this.Lines += cleared;
        this.DropInterval = Math.Max(80, 500 - (this.Level - 1) * 40);
    }

    public int Level { get { return this.Lines / 10 + 1; } }

    private void Spawn()
    {
        this.Board.Piece = this.NextPiece;
        this.Board.Piece.Move(0, Board.W / 2 - 1);
        this.NextPiece = Piece.MakeRandomPiece();
    }

    private bool IsTimeForGravity()
    {
        return (DateTime.Now - this.LastGravity).TotalMilliseconds >= this.DropInterval;
    }
}