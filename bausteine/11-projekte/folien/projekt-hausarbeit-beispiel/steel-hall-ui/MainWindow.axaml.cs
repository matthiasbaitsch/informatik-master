using BoDraw;
using ISections;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace steel_hall_ui;

public partial class MainWindow : Window
{

    public SteelHall SteelHall = new SteelHall("");

    public MainWindow()
    {
        this.InitializeComponent();

        // Profile Stützen
        this.ProfileColumnsCoBo.ItemsSource = ISection.SizesString("HE-A");
        this.ProfileColumnsCoBo.SelectedIndex = 5;

        // Profile Riegel
        this.ProfileBeamsCoBo.ItemsSource = ISection.SizesString("IPE");
        this.ProfileBeamsCoBo.SelectedIndex = 9;

        // Aktionen verdrahten
        this.PlotB.Click += this.OnPlotBClicked;
        this.ExitB.Click += this.OnExitBClicked;

        // Anzeigen
        this.Apply();
    }

    public void Apply()
    {
        this.SteelHall.Project = this.ProjectTB.Text!;
        this.SteelHall.NumberOfFrames = int.Parse(this.NumberOfFramesTB.Text!);
        this.SteelHall.Span = double.Parse(this.SpanTB.Text!);
        this.SteelHall.Height = double.Parse(this.HeightTB.Text!);
        this.SteelHall.FrameSpacing = double.Parse(this.FrameSpacingTB.Text!);
        this.SteelHall.RoofPitch = double.Parse(this.RoofPitchTB.Text!);
        this.SteelHall.ProfileColumns = ISection.Get((string)this.ProfileColumnsCoBo.SelectedItem!);
        this.SteelHall.ProfileBeams = ISection.Get((string)this.ProfileBeamsCoBo.SelectedItem!);

        this.Canvas.Background = Colors.BlanchedAlmond;
        this.Canvas.Clear();
        this.SteelHall.Draw(this.Canvas);
    }

    private void OnPlotBClicked(object? sender, RoutedEventArgs e)
    {
        this.Apply();
    }

    private void OnExitBClicked(object? sender, RoutedEventArgs e)
    {
        this.Close();
    }
}
