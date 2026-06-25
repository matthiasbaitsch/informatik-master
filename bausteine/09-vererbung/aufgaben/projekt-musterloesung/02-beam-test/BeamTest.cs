public class BeamTest
{
    public const double L = 3.2;
    public const double Q = 1.3;

    [Fact]
    public void MAFixedFixed()
    {
        Beam b = new Beam(L, "Fixed", "Fixed", Q);
        Assert.Equal(-Q * L * L / 12, b.MA(), 1e-14);
    }

    [Fact]
    public void MBFixedFixed()
    {
        Beam b = new Beam(L, "Fixed", "Fixed", Q);
        Assert.Equal(-Q * L * L / 12, b.MB(), 1e-14);
    }

    [Fact]
    public void MAFixedPinned()
    {
        Beam b = new Beam(L, "Fixed", "Pinned", Q);
        Assert.Equal(-Q * L * L / 8, b.MA(), 1e-14);
    }

    [Fact]
    public void MBFixedPinned()
    {
        Beam b = new Beam(L, "Fixed", "Pinned", Q);
        Assert.Equal(0.0, b.MB(), 1e-14);
    }

    [Fact]
    public void MAFixedFree()
    {
        Beam b = new Beam(L, "Fixed", "Free", Q);
        Assert.Equal(-Q * L * L / 2, b.MA(), 1e-14);
    }

    [Fact]
    public void MBFixedFree()
    {
        Beam b = new Beam(L, "Fixed", "Free", Q);
        Assert.Equal(0.0, b.MB(), 1e-14);
    }

    [Fact]
    public void MAPinnedFixed()
    {
        Beam b = new Beam(L, "Pinned", "Fixed", Q);
        Assert.Equal(0.0, b.MA(), 1e-14);
    }

    [Fact]
    public void MBPinnedFixed()
    {
        Beam b = new Beam(L, "Pinned", "Fixed", Q);
        Assert.Equal(-Q * L * L / 8, b.MB(), 1e-14);
    }

    [Fact]
    public void MAPinnedPinned()
    {
        Beam b = new Beam(L, "Pinned", "Pinned", Q);
        Assert.Equal(0.0, b.MA(), 1e-14);
    }

    [Fact]
    public void MBPinnedPinned()
    {
        Beam b = new Beam(L, "Pinned", "Pinned", Q);
        Assert.Equal(0.0, b.MB(), 1e-14);
    }

    [Fact]
    public void MAFreeFixed()
    {
        Beam b = new Beam(L, "Free", "Fixed", Q);
        Assert.Equal(0.0, b.MA(), 1e-14);
    }

    [Fact]
    public void MBFreeFixed()
    {
        Beam b = new Beam(L, "Free", "Fixed", Q);
        Assert.Equal(-Q * L * L / 2, b.MB(), 1e-14);
    }

    [Fact]
    public void TestMMaxFixedFixed()
    {
        Beam b = new Beam(L, "Fixed", "Fixed", Q);
        Assert.Equal(Q * L * L / 12, b.MMax(), 1e-14);
    }

    [Fact]
    public void TestMMaxFixedPinned()
    {
        Beam b = new Beam(L, "Fixed", "Pinned", Q);
        Assert.Equal(Q * L * L / 8, b.MMax(), 1e-14);
    }

    [Fact]
    public void TestMMaxFixedFree()
    {
        Beam b = new Beam(L, "Fixed", "Free", Q);
        Assert.Equal(Q * L * L / 2, b.MMax(), 1e-14);
    }

    [Fact]
    public void TestMMaxPinnedFixed()
    {
        Beam b = new Beam(L, "Pinned", "Fixed", Q);
        Assert.Equal(Q * L * L / 8, b.MMax(), 1e-14);
    }

    [Fact]
    public void TestMMaxPinnedPinned()
    {
        Beam b = new Beam(L, "Pinned", "Pinned", Q);
        Assert.Equal(Q * L * L / 8, b.MMax(), 1e-14);
    }

    [Fact]
    public void TestMMaxFreeFixed()
    {
        Beam b = new Beam(L, "Free", "Fixed", Q);
        Assert.Equal(Q * L * L / 2, b.MMax(), 1e-14);
    }

    [Fact]
    public void TestMomentFixedFixed()
    {
        Beam b = new Beam(L, "Fixed", "Fixed", Q);
        Assert.Equal(b.MA(), b.M(0), 1e-14);
        Assert.Equal(Q * L * L / 24, b.M(L / 2), 1e-14);
        Assert.Equal(b.MB(), b.M(L), 1e-14);
    }

    [Fact]
    public void TestMomentFixedPinned()
    {
        Beam b = new Beam(L, "Fixed", "Pinned", Q);
        Assert.Equal(b.MA(), b.M(0), 1e-14);
        Assert.Equal(Q * L * L / 16, b.M(L / 2), 1e-14);
        Assert.Equal(b.MB(), b.M(L), 1e-14);
    }

    [Fact]
    public void TestMomentFixedFree()
    {
        Beam b = new Beam(L, "Fixed", "Free", Q);
        Assert.Equal(b.MA(), b.M(0), 1e-14);
        Assert.Equal(-Q * L * L / 8, b.M(L / 2), 1e-14);
        Assert.Equal(b.MB(), b.M(L), 1e-14);
    }

    [Fact]
    public void TestMomentPinnedFixed()
    {
        Beam b = new Beam(L, "Pinned", "Fixed", Q);
        Assert.Equal(b.MA(), b.M(0), 1e-14);
        Assert.Equal(Q * L * L / 16, b.M(L / 2), 1e-14);
        Assert.Equal(b.MB(), b.M(L), 1e-14);
    }

    [Fact]
    public void TestMomentPinnedPinned()
    {
        Beam b = new Beam(L, "Pinned", "Pinned", Q);
        Assert.Equal(b.MA(), b.M(0), 1e-14);
        Assert.Equal(Q * L * L / 8, b.M(L / 2), 1e-14);
        Assert.Equal(b.MB(), b.M(L), 1e-14);
    }

    [Fact]
    public void TestMomentFreeFixed()
    {
        Beam b = new Beam(L, "Free", "Fixed", Q);
        Assert.Equal(b.MA(), b.M(0), 1e-14);
        Assert.Equal(-Q * L * L / 8, b.M(L / 2), 1e-14);
        Assert.Equal(b.MB(), b.M(L), 1e-14);
    }

}
