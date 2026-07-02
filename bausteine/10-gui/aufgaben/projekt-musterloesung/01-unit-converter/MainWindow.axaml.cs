using Avalonia.Controls;
using Avalonia.Interactivity;

namespace unit_converter;

public partial class MainWindow : Window
{

    // Umrechnungsfaktor Wert mit Einheit -> N/m² (Pa)
    public Dictionary<string, double> Factors = [];

    public MainWindow()
    {
        this.InitializeComponent();

        // Umrechnunsfaktoren speichern
        this.Factors["Pa"] = 1;
        this.Factors["MPa"] = 1e6;
        this.Factors["N/m²"] = 1;
        this.Factors["N/mm²"] = 1e6;
        this.Factors["kN/cm²"] = 1e7;
        this.Factors["PSI"] = 6894.757293168;

        // Einheit Eingangswert
        this.FromUnitCoBo.ItemsSource = this.Factors.Keys;
        this.FromUnitCoBo.SelectedIndex = 0;

        // Einheit Ausgangswert
        this.ToUnitCoBo.ItemsSource = this.Factors.Keys;
        this.ToUnitCoBo.SelectedIndex = 1;

        // Aktion verdrahten
        this.ConvertB.Click += this.OnConvertClick;
    }

    private void OnConvertClick(object? sender, RoutedEventArgs e)
    {
        // Umrechnen
        double input = double.Parse(this.ValueTB.Text!);
        string inputUnit = (string)this.FromUnitCoBo.SelectedItem!;
        string resultUnit = (string)this.ToUnitCoBo.SelectedItem!;
        double a1 = this.Factors[inputUnit];
        double a2 = this.Factors[resultUnit];
        double result = input * a1 / a2;

        // Wert setzen
        this.ResultTB.Text = $"{result:0.0###}";
    }
}
