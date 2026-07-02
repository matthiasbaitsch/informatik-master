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
        this.ValueUnitCoBo.ItemsSource = this.Factors.Keys;
        this.ValueUnitCoBo.SelectedIndex = 0;

        // Einheit Ausgangswert
        this.ResultUnitCoBo.ItemsSource = this.Factors.Keys;
        this.ResultUnitCoBo.SelectedIndex = 1;

        // Aktion verdrahten
        this.ConvertB.Click += this.OnConvertBClicked;
    }

    private void OnConvertBClicked(object? sender, RoutedEventArgs e)
    {
        // Konvertieren
        double input = double.Parse(this.ValueTB.Text!);
        string inputUnit = (string)this.ValueUnitCoBo.SelectedItem!;
        string resultUnit = (string)this.ResultUnitCoBo.SelectedItem!;
        double a1 = this.Factors[inputUnit];
        double a2 = this.Factors[resultUnit];
        double result = input * a1 / a2;

        // Ergebnis anzeigen
        this.ResultTB.Text = $"{result:0.0###############}";
    }
}
