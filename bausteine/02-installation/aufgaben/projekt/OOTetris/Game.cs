namespace OOTetris;

public class Game
{
    private static readonly int[] ScoresForRows = [0, 100, 300, 500, 800];

    private Board board = new Board();
    private int dropInterval = 500;
    private DateTime lastGravityTime = DateTime.Now;
    private bool gameOver = false;
    private int lines = 0;
    private int score = 0;
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
        // Settings
        Console.Clear();
        Console.CursorVisible = false;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // New piece and draw
        this.NewPiece();
        this.Draw();

        // Game loop
        while (!this.gameOver)
        {

            // Handle keybaord input
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Q)
                {
                    this.gameOver = true;
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    this.board.TryMove(0, -1);
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    this.board.TryMove(0, 1);
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    this.board.TryMove(1, 0);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    this.board.TryRotate();
                }
                else if (key == ConsoleKey.Spacebar)
                {
                    while (this.board.TryMove(1, 0)) { }
                    this.XXX();
                }
            }

            // Move piece down if time
            if (this.IsTimeForGravity() && !this.board.TryMove(1, 0))
            {
                this.XXX();
            }

            // Piece does not fit at current position
            if (!this.board.PieceFitsWithOffset(0, 0))
            {
                this.gameOver = true;
            }

            // Draw if game is not over
            if (!this.gameOver)
            {
                this.Draw();
            }

            // Wait a little bit
            Thread.Sleep(16);
        }

        CConsole.WriteLine(23, 0, ConsoleColor.Red, "Game Over");
        CConsole.WriteLine(24, 0, "Drücke Enter...");
        Console.ReadLine();
    }

    private void XXX()
    {
        this.board.Place();
        this.UpdateScore(this.board.ClearRows());
        this.NewPiece();
    }

    private void Draw()
    {
        // Draw board
        this.board.Draw();

        // Column right of board
        int c = 2 * Board.W + 5;

        // Clear area and draw next piece
        for (int r = 0; r < 4; r++)
        {
            CConsole.Write(1 + r, c, "        ");
        }
        foreach (var b in this.nextPiece.Bricks)
        {
            CConsole.Write(1 + b[0], c + 2 * b[1], this.nextPiece.Color, "██");
        }

        // Score and hints
        CConsole.Write(06, c, "Lines: " + this.lines);
        CConsole.Write(07, c, "Level: " + this.Level);
        CConsole.Write(08, c, "Score: " + this.score);
        CConsole.Write(16, c, "  ← →  Bewegen");
        CConsole.Write(17, c, "   ↑   Drehen");
        CConsole.Write(18, c, "   ↓   Schneller");
        CConsole.Write(19, c, " Space Fallenlassen");
        CConsole.Write(20, c, "   q   Ende");
    }


    private void UpdateScore(int cleared)
    {
        this.score += this.Level * Game.ScoresForRows[cleared];
        this.lines += cleared;
        this.dropInterval = Math.Max(80, 500 - (this.Level - 1) * 40);
    }

    private void NewPiece()
    {
        this.board.Piece = this.nextPiece;
        this.board.Piece.Move(0, Board.W / 2 - 1);
        this.nextPiece = Piece.RandomPiece();
    }

    private bool IsTimeForGravity()
    {
        bool b = (DateTime.Now - this.lastGravityTime).TotalMilliseconds >= this.dropInterval;
        if (b)
        {
            this.lastGravityTime = DateTime.Now;
        }
        return b;
    }
}