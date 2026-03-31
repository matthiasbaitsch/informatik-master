namespace OOTetris.Tests;

using OOTetris;

public class BoardTest
{
    [Fact]
    public void TestFit()
    {
        Board b = new Board();
        b.Piece = Piece.MakePiece(Piece.Type.O);

        Assert.True(b.PieceFitsWithOffset(0, 0));
        Assert.True(b.PieceFitsWithOffset(18, 8));
        Assert.True(b.PieceFitsWithOffset(1, 1));
        Assert.False(b.PieceFitsWithOffset(19, 0));
        Assert.False(b.PieceFitsWithOffset(0, 9));
        Assert.False(b.PieceFitsWithOffset(-1, 0));
        Assert.False(b.PieceFitsWithOffset(0, -1));
    }
}
