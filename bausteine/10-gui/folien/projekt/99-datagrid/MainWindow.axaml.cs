using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;

namespace datagrid;

public partial class MainWindow : Window
{
    public ObservableCollection<Person> People =
    [
        new Person("Ada Lovelace", 36),
        new Person("Alan Turing", 41),
        new Person("Grace Hopper", 85),
    ];

    public MainWindow()
    {
        this.InitializeComponent();

        this.PersonsTBL.ItemsSource = this.People;
        this.PersonsTBL.AutoGeneratingColumn += this.ColumnGenerated;

        this.AddRowB.Click += this.AddRowBClicked;
        this.DeleteRowB.Click += this.DeleteRowBClicked;
        this.PrintB.Click += this.PrintBClicked;
    }

    private void ColumnGenerated(object? sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "Name")
        {
            e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
        else
        {
            e.Column.Width = DataGridLength.Auto;
        }
    }

    private void AddRowBClicked(object? sender, RoutedEventArgs e)
    {
        int row = this.PersonsTBL.SelectedIndex;
        if (row >= 0)
        {
            this.People.Insert(row + 1, new Person("", 0));
        }
        else
        {
            this.People.Add(new Person("", 0));
        }
    }

    private void DeleteRowBClicked(object? sender, RoutedEventArgs e)
    {
        int row = this.PersonsTBL.SelectedIndex;
        if (row >= 0)
        {
            this.People.RemoveAt(row);
        }
    }

    private void PrintBClicked(object? sender, RoutedEventArgs e)
    {
        foreach (Person p in this.People)
        {
            Console.WriteLine(p);
        }
    }
}