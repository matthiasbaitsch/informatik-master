using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace good_to_know_custom_control;

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