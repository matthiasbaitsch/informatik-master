using Avalonia.Controls;
using Avalonia.Interactivity;

namespace clickme;

public partial class MainWindow : Window
{

    public int Count = 1;

    public MainWindow()
    {
        this.InitializeComponent();
        this.ClickmeB.Click += this.OnClickmeClicked;
    }

    public void OnClickmeClicked(object? sender, RoutedEventArgs e)
    {
        this.ClickmeB.Content = $"Clicked {this.Count++} times";
    }
}