using Avalonia.Controls;
using Avalonia.Interactivity;

namespace good_to_know_user_control;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();
        this.ApplyB.Click += this.ApplyClicked;
    }

    private void ApplyClicked(object? sender, RoutedEventArgs e)
    {
        RectangularSection s1 = this.Section1Ctrl.CreateSection();
        this.Area1TBl.Text = $"Area is A = {s1.A()} cm²";

        RectangularSection s2 = this.Section2Ctrl.CreateSection();
        this.Area2TBl.Text = $"Area is A = {s2.A()} cm²";
    }
}