using static System.Math;

public class SectionTest
{
    [Fact]
    public void RectangularSectionA()
    {
        RectangularSection s = new RectangularSection(20, 40);
        Assert.Equal(800, s.A(), 1e-14);
    }

    [Fact]
    public void RectangularSectionIy()
    {
        RectangularSection s = new RectangularSection(20, 40);
        Assert.Equal(106666.6667, s.Iy(), 1e-3);
    }

    [Fact]
    public void RectangularSectionIz()
    {
        RectangularSection s = new RectangularSection(20, 40);
        Assert.Equal(26666.6667, s.Iz(), 1e-4);
    }

    [Fact]
    public void ISectionA()
    {
        ISection s = new ISection(20, 40, 0.5, 1);
        Assert.Equal(59, s.A(), 1e-14);
    }

    [Fact]
    public void ISectionIy()
    {
        ISection s = new ISection(20, 40, 0.5, 1);
        Assert.Equal(17499.6667, s.Iy(), 1e-4);
    }

    [Fact]
    public void ISectionIz()
    {
        ISection s = new ISection(20, 40, 0.5, 1);
        Assert.Equal(1333.7292, s.Iz(), 1e-4);
    }
}
