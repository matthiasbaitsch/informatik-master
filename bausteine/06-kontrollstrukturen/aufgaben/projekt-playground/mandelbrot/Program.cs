using BoDraw;


BoDrawApp app = new BoDrawApp();

MandelbrotSet set = new MandelbrotSet();
set.N = 20;

if (true)
{
    Image image = new Image(2600, 2600, -2.5, -2, 4);
    ColorMap cm = ColorMap.Inferno.WithRange(1, set.N);

    foreach (var p in image.Pixels)
    {
        p.Color = cm.Map(set.StepsInside(new Complex(p.X, p.Y)));
    }
    app.Add(image);
}
else
{
    double d = 0.02;
    Complex c1 = new Complex(-2, -1.1);
    Complex c2 = new Complex(0.7, 1.1);
    Complex c = new Complex(c1.Re, c1.Im);
    while (c.Re <= c2.Re && c.Im <= c2.Im)
    {
        Circle point = new Circle(c.Re, c.Im, d / 2.5);
        point.LineColor = null;
        if (set.Contains(c))
        {
            point.FillColor = Colors.Red;
        }
        else
        {
            point.FillColor = Colors.SteelBlue;
        }
        app.Add(point);

        c.Re += d;
        if (c.Re > c2.Re)
        {
            c.Re = c1.Re;
            c.Im += d;
        }
    }
}

app.Show();


