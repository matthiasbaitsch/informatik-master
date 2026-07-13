using BoDraw;
using Avalonia.Controls;

namespace output_controls_bodraw;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();
        this.Canvas.Add(new Circle(0, 0, 1).WithFillColor(Colors.HotPink));
    }
}