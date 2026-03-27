prepare-render:
	cd lernpfad/skripte && julia --project lernpfad-zusammenstellen.jl

render: prepare-render
	quarto render lernpfad/folien -t revealjs
	quarto render lernpfad/aufgaben -t html
	quarto render lernpfad/aufgaben -t typst

clean:
	rm -rf lernpfad/*/c
	rm -rf __output
