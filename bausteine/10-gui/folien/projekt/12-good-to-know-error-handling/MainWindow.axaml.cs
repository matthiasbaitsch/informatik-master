using MsBox.Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace good_to_know_error_handling;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();
        this.ComputeB.Click += this.OnComputeClicked;
        this.Compute();
    }

    public async void OnComputeClicked(object? sender, RoutedEventArgs e)
    {
        try
        {
            this.Compute();
        }
        catch (Exception)
        {
            await MessageBoxManager.GetMessageBoxStandard("Error", "Invalid Input!").ShowAsync();
        }
    }

    public void Compute()
    {
        double load = double.Parse(this.LoadTB.Text!);
        this.ResultTBl.Text = $"Total load: {5.0 * load} kN";
    }
}
