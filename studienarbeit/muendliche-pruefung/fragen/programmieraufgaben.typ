// Programmieraufgaben für die mündliche Prüfung zur Studienarbeit
// Sechs Karten pro A4-Seite (2 Spalten × 3 Zeilen), Schnittlinien gestrichelt
// Inhalte stehen in aufgaben.typ
// Übersetzen mit: typst compile programmieraufgaben.typ

#import "aufgaben.typ": tasks

#set page(paper: "a4", margin: 0pt)
#set text(font: "Source Sans Pro", size: 10.5pt, lang: "de")
#set par(leading: 0.55em, spacing: 0.75em)
#set list(indent: 0.2em, body-indent: 0.5em, spacing: 0.5em)
#set enum(indent: 0.2em, body-indent: 0.5em, spacing: 0.5em)
#show raw: set text(font: "Source Code Pro", size: 9.4pt)

#let columns = 2
#let rows = 3
#let card-width = 210mm / columns
#let card-height = 297mm / rows
#let accent = rgb("#00508c")

#let card(nr, task) = box(
  width: card-width,
  height: card-height,
  inset: (x: 7mm, top: 6mm, bottom: 5mm),
  clip: true,
)[
  #grid(
    columns: (1fr, auto),
    text(size: 8pt, fill: luma(110))[Aufgabe #nr],
    text(size: 8pt, fill: luma(110), task.topic),
  )
  #v(-0.2em)
  #text(size: 13.5pt, weight: "bold", fill: accent, task.title)
  #v(0.1em)
  #task.body
  #if task.at("extension", default: none) != none {
    v(0.2em)
    block(
      stroke: (left: 1.5pt + accent),
      inset: (left: 2.5mm, y: 0.6mm),
    )[*Erweiterung:* #task.extension]
  }
]

#let cards = tasks.enumerate().map(((i, task)) => card(i + 1, task))

#for page-cards in cards.chunks(columns * rows) {
  grid(
    columns: (card-width,) * columns,
    rows: card-height,
    stroke: (paint: luma(170), thickness: 0.4pt, dash: "dashed"),
    ..page-cards,
  )
  pagebreak(weak: true)
}
