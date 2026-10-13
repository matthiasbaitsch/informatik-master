// Übersicht der Programmieraufgaben für die mündliche Prüfung (für Prüfende)
// Inhalte stehen in aufgaben.typ
// Übersetzen mit: typst compile uebersicht.typ

#import "aufgaben.typ": tasks

#set page(paper: "a4", flipped: true, margin: (x: 12mm, y: 10mm))
#set text(font: "Source Sans Pro", size: 8.5pt, lang: "de")
#set par(leading: 0.4em)
#show raw: set text(font: "Source Code Pro", size: 7.8pt)

#let accent = rgb("#00508c")

#text(size: 12pt, weight: "bold", fill: accent)[Programmieraufgaben mündliche Prüfung – Übersicht]
#v(-0.2em)

#table(
  columns: (auto, auto, auto, 1fr, auto),
  inset: (x: 4pt, y: 2.6pt),
  stroke: (x, y) => (bottom: 0.4pt + luma(190)),
  fill: (x, y) => if y == 0 { accent.lighten(85%) },
  table.header([*Nr.*], [*Titel*], [*Thema*], [*Inhalt*], [*Ergebnisse*]),
  ..tasks
    .enumerate()
    .map(((i, task)) => (
      [#(i + 1)],
      task.title,
      task.topic,
      task.summary,
      task.at("results", default: []),
    ))
    .flatten(),
)
