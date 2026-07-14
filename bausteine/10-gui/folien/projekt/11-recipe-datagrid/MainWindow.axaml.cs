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
        this.PersonsDG.AutoGeneratingColumn += this.OnColumnGenerated;

        this.AddRowB.Click += this.OnAddRowClicked;
        this.DeleteRowB.Click += this.OnDeleteRowClicked;
        this.PrintB.Click += this.OnPrintClicked;
    }

    public void OnColumnGenerated(object? sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "Age")
        {
            e.Column.Width = DataGridLength.Auto;
        }
    }

    public void OnAddRowClicked(object? sender, RoutedEventArgs e)
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

    public void OnDeleteRowClicked(object? sender, RoutedEventArgs e)
    {
        int row = this.PersonsDG.SelectedIndex;

        if (row >= 0)
        {
            this.Persons.RemoveAt(row);
        }
    }

    public void OnPrintClicked(object? sender, RoutedEventArgs e)
    {
        foreach (Person p in this.Persons)
        {
            Console.WriteLine(p);
        }
    }
}