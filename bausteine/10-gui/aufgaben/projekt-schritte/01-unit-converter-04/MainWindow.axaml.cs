using Avalonia.Controls;
using Avalonia.Interactivity;

namespace unit_converter;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        this.InitializeComponent();

        // Aktion verdrahten
        this.ConvertB.Click += this.OnConvertBClicked;
    }

    private void OnConvertBClicked(object? sender, RoutedEventArgs e)
    {
        // Konvertieren
        double input = double.Parse(this.ValueTB.Text!);
        double result = input / 6894.757293168;

        // Anzeigen
        this.ResultTB.Text = $"{result:0.0####}";
    }
}
