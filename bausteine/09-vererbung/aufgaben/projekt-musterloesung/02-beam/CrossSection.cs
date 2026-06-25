using BoDraw;

public abstract class CrossSection
{
    public abstract double A();

    public abstract double Iy();

    public abstract double Iz();

    public abstract double Height();

    public abstract Shape Draw();
}
