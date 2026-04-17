# Vorlesungsunterlagen Informatik – Master Bauingenieurwesen

## Kontext

Dieses Projekt enthält die Lehrveranstaltungsunterlagen für das Modul **Informatik im Master Bauingenieurwesen** an der **Hochschule Bochum**.

Die Studierenden lernen **objektorientiertes Programmieren mit C#**. Zielgruppe sind Bauingenieur-Masterstudierende ohne vertiefte Programmiererfahrung.

## Lernziele

- Studierende sollen die vermittelten Konzepte **selbständig anwenden** können – Verständnis und Transfer stehen im Vordergrund, nicht das Auswendiglernen von Syntax
- Das Modul legt eine **solide konzeptuelle Basis**; Sprachdetails können Studierende bei Bedarf später selbständig erarbeiten
- Der behandelte Sprachumfang beschränkt sich auf die **wesentlichen OOP-Konzepte**: Klassen, Objekte, Kapselung, Vererbung, Polymorphismus
- Komplexe oder randständige C#-Features werden bewusst weggelassen

## Technischer Aufbau

- **Format:** Quarto (`.qmd`), Deutsch
- **Ausgabeformate:** Reveal.js-Folien und HTML-Seiten (konfiguriert in `_quarto.yml`)
- **Struktur pro Themenpaket:** Verzeichnis `XX-thema/` mit
  - `about.yml` – Lernziele und Übersicht des Pakets
  - `folien/folien.qmd` – Vorlesungsfolien
  - `aufgaben/*.qmd` – Aufgaben und Projektaufgaben
  - `aufgaben/projekt/` – Aufgaben-Startcode
  - `aufgaben/projekt-loesung/` – Musterlösung
- **Entwicklungsumgebung der Studierenden:** Visual Studio Code mit C# Dev Kit

## Arbeitshinweise für Claude

- Linter-Hinweise in `.qmd`-Dateien ignorieren – das macht der Nutzer selbst
- Reihenfolge Beispiel vor Erklärung nicht als Problem werten – didaktisch bewusst so

## Inhaltliche Richtlinien

- Alle Texte auf **Deutsch** (Siezen: „Sie")
- C#-Code soll klar und lesbar sein – keine cleveren Shortcuts, keine fortgeschrittenen Features ohne expliziten Grund
- **Bezeichner** (Variablen, Methoden, Klassen) auf **Englisch**, **Kommentare** auf **Deutsch**
- Ordner- und Dateinamen in C#-Projekten pragmatisch: Einführungspakete (wo Namen Lernkonzepte bezeichnen) auf Deutsch, ab OOP-Paketen englisch
- Aufgaben sollen schrittweise aufgebaut sein und auf ingenieurwissenschaftliche Anwendungsfälle eingehen, wo sinnvoll
- Musterlösungen in `projekt-loesung/` sollen dem Kenntnisstand der Studierenden entsprechen
