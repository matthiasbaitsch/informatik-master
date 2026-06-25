using BoDraw;

public class Structure
{
    public double A;
    public List<StructuralElement> Elements = [];

    public Structure(double a)
    {
        this.A = a;
    }

    public void Add(StructuralElement e)
    {
        this.Elements.Add(e);
    }

    public Group Draw()
    {
        Group group = new Group();
        foreach (StructuralElement e in this.Elements)
        {
            group.Add(e.Draw(this.A));
        }
        return group;
    }
}