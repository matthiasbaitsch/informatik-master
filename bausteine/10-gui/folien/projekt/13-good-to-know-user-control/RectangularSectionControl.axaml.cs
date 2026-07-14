using Avalonia.Controls;

namespace good_to_know_user_control;

public partial class RectangularSectionControl : UserControl
{
    public RectangularSectionControl()
    {
        this.InitializeComponent();
    }

    public RectangularSection CreateSection()
    {
        double w = double.Parse(this.WidthTB.Text!);
        double h = double.Parse(this.HeightTB.Text!);
        return new RectangularSection(w, h);
    }
}