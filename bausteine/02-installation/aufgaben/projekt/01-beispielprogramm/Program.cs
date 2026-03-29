class Tetris
{
    const int W = 10, H = 20;
    static int[,] board = new int[H, W];
    static int score = 0, level = 1, lines = 0;
    static bool gameOver = false;

    // Tetrominoes: [piece][rotation][block] = (row, col)
    static int[][][][] pieces =
    [
        // I
        [
            [[0,0],[0,1],[0,2],[0,3]],
            [[0,0],[1,0],[2,0],[3,0]]
        ],
        // O
        [
            [[0,0],[0,1],[1,0],[1,1]]
        ],
        // T
        [
            [[0,1],[1,0],[1,1],[1,2]],
            [[0,0],[1,0],[1,1],[2,0]],
            [[0,0],[0,1],[0,2],[1,1]],
            [[0,1],[1,0],[1,1],[2,1]]
        ],
        // S
        [
            [[0,1],[0,2],[1,0],[1,1]],
            [[0,0],[1,0],[1,1],[2,1]]
        ],
        // Z
        [
            [[0,0],[0,1],[1,1],[1,2]],
            [[0,1],[1,0],[1,1],[2,0]]
        ],
        // J
        [
            [[0,0],[1,0],[1,1],[1,2]],
            [[0,0],[0,1],[1,0],[2,0]],
            [[0,0],[0,1],[0,2],[1,2]],
            [[0,1],[1,1],[2,0],[2,1]]
        ],
        // L
        [
            [[0,2],[1,0],[1,1],[1,2]],
            [[0,0],[1,0],[2,0],[2,1]],
            [[0,0],[0,1],[0,2],[1,0]],
            [[0,0],[0,1],[1,1],[2,1]]
        ]
    ];

    // Colors per piece (1-indexed on board)
    static ConsoleColor[] colors = [
        ConsoleColor.Cyan,    // I
        ConsoleColor.Yellow,  // O
        ConsoleColor.Magenta, // T
        ConsoleColor.Green,   // S
        ConsoleColor.Red,     // Z
        ConsoleColor.Blue,    // J
        ConsoleColor.DarkYellow // L
    ];

    static int curPiece, curRot, curRow, curCol;
    static int nextPiece;
    static Random rng = new Random();

    static int NewPiece() => rng.Next(pieces.Length);

    static bool Fits(int piece, int rot, int row, int col)
    {
        foreach (var b in pieces[piece][rot % pieces[piece].Length])
        {
            int r = row + b[0], c = col + b[1];
            if (r < 0 || r >= H || c < 0 || c >= W) return false;
            if (board[r, c] != 0) return false;
        }
        return true;
    }

    static void Place()
    {
        int rotIdx = curRot % pieces[curPiece].Length;
        foreach (var b in pieces[curPiece][rotIdx])
            board[curRow + b[0], curCol + b[1]] = curPiece + 1;
    }

    static int ClearLines()
    {
        int cleared = 0;
        for (int r = H - 1; r >= 0; r--)
        {
            bool full = true;
            for (int c = 0; c < W; c++) if (board[r, c] == 0) { full = false; break; }
            if (full)
            {
                cleared++;
                for (int rr = r; rr > 0; rr--)
                    for (int c = 0; c < W; c++)
                        board[rr, c] = board[rr - 1, c];
                for (int c = 0; c < W; c++) board[0, c] = 0;
                r++;
            }
        }
        return cleared;
    }

    static void Spawn()
    {
        curPiece = nextPiece;
        nextPiece = NewPiece();
        curRot = 0;
        curRow = 0;
        curCol = W / 2 - 1;
        if (!Fits(curPiece, curRot, curRow, curCol))
            gameOver = true;
    }

    static void Draw()
    {
        Console.SetCursorPosition(0, 0);
        int rotIdx = curRot % pieces[curPiece].Length;
        var ghost = GetGhost();

        // Top borderq
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("┌");
        for (int c = 0; c < W; c++) Console.Write("──");
        Console.WriteLine("┐   ");

        for (int r = 0; r < H; r++)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("│");
            for (int c = 0; c < W; c++)
            {
                bool isActive = false, isGhost = false;
                foreach (var b in pieces[curPiece][rotIdx])
                    if (curRow + b[0] == r && curCol + b[1] == c) { isActive = true; break; }
                if (!isActive)
                    foreach (var g in ghost)
                        if (g[0] == r && g[1] == c) { isGhost = true; break; }

                if (isActive)
                {
                    Console.ForegroundColor = colors[curPiece];
                    Console.Write("██");
                }
                else if (isGhost)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("░░");
                }
                else if (board[r, c] != 0)
                {
                    Console.ForegroundColor = colors[board[r, c] - 1];
                    Console.Write("██");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("  ");
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("│");

            // Side panel
            Console.ForegroundColor = ConsoleColor.White;
            if (r == 1) Console.Write("  TETRIS");
            else if (r == 3) { Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("  Punkte:"); }
            else if (r == 4) { Console.ForegroundColor = ConsoleColor.Yellow; Console.Write($"  {score,8}"); }
            else if (r == 6) { Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("  Level:"); }
            else if (r == 7) { Console.ForegroundColor = ConsoleColor.Cyan; Console.Write($"  {level,8}"); }
            else if (r == 9) { Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("  Linien:"); }
            else if (r == 10) { Console.ForegroundColor = ConsoleColor.Green; Console.Write($"  {lines,8}"); }
            else if (r == 12) { Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("  Nächstes:"); }
            else if (r >= 13 && r <= 16) DrawNextPieceRow(r - 13);
            else if (r == 18) { Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("  ← →  Bewegen"); }
            else if (r == 19) { Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write("  ↑    Drehen"); }
            else Console.Write("  ");

            Console.WriteLine();
        }

        // Bottom border
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("└");
        for (int c = 0; c < W; c++) Console.Write("──");
        Console.WriteLine("┘   ");
        Console.Write("  ↓    Schneller   Space: Drop   Q: Quit");
        Console.ResetColor();
    }

    static void DrawNextPieceRow(int row)
    {
        int rotIdx = 0;
        var blocks = pieces[nextPiece][rotIdx];
        // Find min row offset
        int minRow = 99;
        foreach (var b in blocks) if (b[0] < minRow) minRow = b[0];

        Console.Write("  ");
        for (int c = 0; c < 4; c++)
        {
            bool found = false;
            foreach (var b in blocks)
                if (b[0] - minRow == row && b[1] == c) { found = true; break; }
            if (found) { Console.ForegroundColor = colors[nextPiece]; Console.Write("██"); }
            else Console.Write("  ");
        }
    }

    static List<int[]> GetGhost()
    {
        int ghostRow = curRow;
        int rotIdx = curRot % pieces[curPiece].Length;
        while (Fits(curPiece, curRot, ghostRow + 1, curCol)) ghostRow++;
        var result = new List<int[]>();
        if (ghostRow != curRow)
            foreach (var b in pieces[curPiece][rotIdx])
                result.Add([ghostRow + b[0], curCol + b[1]]);
        return result;
    }

    static void HardDrop()
    {
        while (Fits(curPiece, curRot, curRow + 1, curCol)) curRow++;
    }

    static void Main()
    {
        Console.CursorVisible = false;
        Console.Clear();
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        nextPiece = NewPiece();
        Spawn();
        Draw();

        int dropInterval = 500;
        DateTime lastDrop = DateTime.Now;

        while (!gameOver)
        {
            // Input
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Q) { gameOver = true; break; }
                else if (key == ConsoleKey.LeftArrow) { if (Fits(curPiece, curRot, curRow, curCol - 1)) curCol--; }
                else if (key == ConsoleKey.RightArrow) { if (Fits(curPiece, curRot, curRow, curCol + 1)) curCol++; }
                else if (key == ConsoleKey.DownArrow) { if (Fits(curPiece, curRot, curRow + 1, curCol)) curRow++; }
                else if (key == ConsoleKey.UpArrow)
                {
                    int newRot = (curRot + 1) % pieces[curPiece].Length;
                    if (Fits(curPiece, newRot, curRow, curCol)) curRot = newRot;
                    else if (Fits(curPiece, newRot, curRow, curCol + 1)) { curRot = newRot; curCol++; }
                    else if (Fits(curPiece, newRot, curRow, curCol - 1)) { curRot = newRot; curCol--; }
                }
                else if (key == ConsoleKey.Spacebar)
                {
                    HardDrop();
                    Place();
                    int c = ClearLines();
                    lines += c;
                    score += c == 0 ? 0 : (new[] { 0, 100, 300, 500, 800 }[c] * level);
                    level = lines / 10 + 1;
                    dropInterval = Math.Max(80, 500 - (level - 1) * 40);
                    Spawn();
                }
            }

            // Gravity
            if ((DateTime.Now - lastDrop).TotalMilliseconds >= dropInterval)
            {
                if (Fits(curPiece, curRot, curRow + 1, curCol))
                    curRow++;
                else
                {
                    Place();
                    int c = ClearLines();
                    lines += c;
                    score += c == 0 ? 0 : (new[] { 0, 100, 300, 500, 800 }[c] * level);
                    level = lines / 10 + 1;
                    dropInterval = Math.Max(80, 500 - (level - 1) * 40);
                    Spawn();
                }
                lastDrop = DateTime.Now;
            }

            Draw();
            Thread.Sleep(16);
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n  ╔══════════════════╗");
        Console.WriteLine("  ║   GAME  OVER!    ║");
        Console.WriteLine("  ╚══════════════════╝");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n  Punkte : {score}");
        Console.WriteLine($"  Level  : {level}");
        Console.WriteLine($"  Linien : {lines}");
        Console.ResetColor();
        Console.WriteLine("\n  Drücke Enter...");
        Console.ReadLine();
    }
}