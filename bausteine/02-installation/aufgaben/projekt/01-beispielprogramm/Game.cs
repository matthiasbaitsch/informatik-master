namespace OOTetris;

public class Game
{
    private static readonly int[] ScoresForRows = [0, 100, 300, 500, 800];

    private int lines = 0;
    private int score = 0;
    private int cleared = 0;
    private int lastCleared = 0;
    private int dropInterval = 500;
    private bool gameOver = false;
    private Board board = new Board();
    private DateTime lastDropTime = DateTime.Now;
    private Piece nextPiece = Piece.RandomPiece();

    public int Level
    {
        get
        {
            return this.lines / 10 + 1;
        }
    }

    public void Play()
    {
        // Get ready
        Console.Clear();
        Console.CursorVisible = false;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Game loop
        while (!this.gameOver)
        {
            this.ProcessInput();
            this.TryDropPiece();
            this.TryPlacePiece();
            this.TryPutNextPiece();
            this.UpdateScore();
            this.Draw();
            Thread.Sleep(16);
        }

        // Game over
        CConsole.WriteLine(23, 0, ConsoleColor.Red, "Game Over");
        CConsole.WriteLine(24, 0, "Drücke Enter...");
        Console.ReadLine();
    }

    private void ProcessInput()
    {
        while (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Q)
            {
                this.gameOver = true;
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                this.board.TryMovePiece(0, -1);
            }
            else if (key == ConsoleKey.RightArrow)
            {
                this.board.TryMovePiece(0, 1);
            }
            else if (key == ConsoleKey.DownArrow)
            {
                this.board.TryMovePiece(1, 0);
            }
            else if (key == ConsoleKey.UpArrow)
            {
                this.board.TryRotatePiece();
            }
            else if (key == ConsoleKey.Spacebar)
            {
                while (this.board.CanMovePiece(1, 0))
                {
                    this.board.MovePiece(1, 0);
                }
                this.lastDropTime = DateTime.MinValue;
            }
        }
    }

    private void TryDropPiece()
    {
        if (this.DropIntervalPassed() && this.board.CanMovePiece(1, 0))
        {
            this.board.MovePiece(1, 0);
            this.lastDropTime = DateTime.Now;
        }
    }

    private void TryPlacePiece()
    {
        if (this.DropIntervalPassed() && this.board.HasPiece() && !this.board.CanMovePiece(1, 0))
        {
            this.board.Place();
            this.lastCleared = this.cleared = this.board.ClearRows();
            this.lastDropTime = DateTime.Now;
        }
    }

    private void TryPutNextPiece()
    {
        if (!this.board.HasPiece())
        {
            this.board.TryPutPiece(this.nextPiece);
            this.nextPiece = Piece.RandomPiece();
            this.lastDropTime = DateTime.Now;
        }
    }

    private void UpdateScore()
    {
        this.lines += this.cleared;
        this.score += this.Level * Game.ScoresForRows[this.cleared];
        this.dropInterval = Math.Max(80, 500 - (this.Level - 1) * 40);
        this.cleared = 0;

        if (!this.board.HasPiece())
        {
            this.gameOver = true;
        }
    }

    private void Draw()
    {
        // Draw board
        this.board.Draw();

        // Column right of board
        int col = 2 * Board.Width + 5;

        // Clear area and draw next piece
        for (int r = 0; r < 4; r++)
        {
            CConsole.Write(1 + r, col, "        ");
        }
        foreach (var b in this.nextPiece.Bricks)
        {
            CConsole.Write(1 + b[0], col + 2 * b[1], this.nextPiece.Color, "██");
        }

        // Score
        CConsole.Write(6, col, "Lines: " + this.lines);
        CConsole.Write(7, col, "Level: " + this.Level);
        CConsole.Write(8, col, "Score: " + this.score);
        CConsole.Write(9, col, "💥".Repeat(this.lastCleared) + " ".Repeat(4 - this.lastCleared));

        // Hints
        CConsole.Write(16, col, "  ← →  Bewegen");
        CConsole.Write(17, col, "   ↑   Drehen");
        CConsole.Write(18, col, "   ↓   Schneller");
        CConsole.Write(19, col, " Space Fallenlassen");
        CConsole.Write(20, col, "   q   Ende");
    }

    private bool DropIntervalPassed()
    {
        return (DateTime.Now - this.lastDropTime).TotalMilliseconds >= this.dropInterval;
    }
}