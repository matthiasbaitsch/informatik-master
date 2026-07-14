using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;

namespace recipe_datagrid;

public partial class MainWindow : Window
{
    public ObservableCollection<Person> Persons = [
        new Person("Ada Lovelace", 36),
        new Person("Alan Turing", 41),
        new Person("Grace Hopper", 85),
    ];

    public MainWindow()
    {
        this.InitializeComponent();

        this.PersonsDG.ItemsSource = this.Persons;
        this.PersonsDG.AutoGeneratingColumn += this.ColumnGenerated;

        this.AddRowB.Click += this.AddRowClicked;
        this.DeleteRowB.Click += this.DeleteRowClicked;
        this.PrintB.Click += this.PrintClicked;
    }

    private void ColumnGenerated(object? sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "Age")
        {
            e.Column.Width = DataGridLength.Auto;
        }
    }

    private void AddRowClicked(object? sender, RoutedEventArgs e)
    {
        int row = this.PersonsDG.SelectedIndex;

        if (row >= 0)
        {
            this.Persons.Insert(row + 1, new Person("", 0));
        }
        else
        {
            this.Persons.Add(new Person("", 0));
        }
    }

    private void DeleteRowClicked(object? sender, RoutedEventArgs e)
    {
        int row = this.PersonsDG.SelectedIndex;

        if (row >= 0)
        {
            this.Persons.RemoveAt(row);
        }
    }

    private void PrintClicked(object? sender, RoutedEventArgs e)
    {
        foreach (Person p in this.Persons)
        {
            Console.WriteLine(p);
        }
    }
}