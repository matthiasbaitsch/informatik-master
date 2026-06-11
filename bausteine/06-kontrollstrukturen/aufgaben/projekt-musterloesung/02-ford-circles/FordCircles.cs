using BoDraw;
using static System.Math;

int n = 20;
Group group = new Group();
ColorMap colormap = ColorMap.Jet.WithRange(Log(1.0 / (2 * n * n)), Log(0.5));

for (int a = 0; a <= n; a++)
{
    for (int b = a; b <= n; b++)
    {
        if (b != 0)
        {
            Fraction q = new Fraction(a, b);
            if (q.Equals(q.Simplify()))
            {
                double r = 1.0 / (2 * q.B * q.B);
                Circle c = new Circle(q.ToDouble(), r, r);
                c.FillColor = colormap.Map(Log(r));
                group.Add(c);

                if (b <= 6)
                {
                    Text t = new Text($"{q.A}/{q.B}", q.ToDouble(), 0, 0.016);
                    t.HJust = 0.5;
                    t.VJust = 1.1;
                    group.Add(t);
                }
            }
        }
    }
}

BoDrawApp app = new BoDrawApp();
app.Add(new Clip(group, new Rectangle(-0.02, -0.03, 1.02, 0.6)));
app.Show();