Hier die komplette Liste – ausgehend vom leeren Avalonia-Template waren es fünf Stellen:

1. datagrid.csproj – Paket hinzufügen. Das DataGrid steckt nicht im Avalonia-Kernpaket:

<PackageReference Include="Avalonia.Controls.DataGrid" Version="12.0.1" />

2. App.axaml – Theme einbinden. Ohne diese Zeile ist das DataGrid unsichtbar (ohne Fehlermeldung):

<StyleInclude Source="avares://Avalonia.Controls.DataGrid/Themes/Fluent.xaml"/>

3. MainWindow.axaml – das Control selbst. DataGrid mit x:Name und Spaltendefinitionen; dazu oben der Namespace xmlns:local="using:datagrid". Das x:DataType="local:Person" an den Spalten ist nötig, weil das Template kompilierte Bindings aktiviert (AvaloniaUseCompiledBindingsByDefault in der csproj) – der Compiler muss wissen, auf welchem Typ Name und Age liegen:

<DataGrid x:Name="PersonsTBL" AutoGenerateColumns="False">
    <DataGrid.Columns>
        <DataGridTextColumn Header="Name" Binding="{Binding Name}" x:DataType="local:Person"/>
        <DataGridTextColumn Header="Alter" Binding="{Binding Age}" x:DataType="local:Person"/>
    </DataGrid.Columns>
</DataGrid>

4. Person.cs – Datenklasse mit Properties. Der entscheidende Punkt: { get; set; } statt bloßer Felder, sonst bleibt die Tabelle leer:

public string Name { get; set; }
public int Age { get; set; }

5. MainWindow.axaml.cs – Daten zuweisen. Liste anlegen und im Konstruktor ans Grid hängen:

this.PersonsTBL.ItemsSource = this.people;
Die zwei Fallen, die bei dir konkret zugeschlagen hatten, waren 2 (fehlendes Theme) und 4 (Felder statt Properties) – beides scheitert stumm, deshalb war es schwer zu sehen. Punkt 5 fehlte ebenfalls noch.