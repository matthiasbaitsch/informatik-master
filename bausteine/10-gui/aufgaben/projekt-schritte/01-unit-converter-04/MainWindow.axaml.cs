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
        double result = 6894.757293168 * input;

        // Anzeigen
        this.ResultTB.Text = $"{result:0.0####}";
    }
}
