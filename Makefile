prepare-render:
	cd lernpfad/skripte && julia --project lernpfad-zusammenstellen.jl

render: prepare-render
	quarto render lernpfad/folien -t revealjs
	quarto render lernpfad/aufgaben

copy-templates:
	for f in bausteine/*/aufgaben/projekt*; do \
		package=`echo $$f | cut -d'/' -f2 | sed 's/^[0-9]*-//'`; \
		cp bausteine/00-templates/.editorconfig $$f; \
		cp bausteine/00-templates/projekt.code-workspace $$f/$$package.code-workspace; \
	done

clean:
	rm -rf lernpfad/*/c
	rm -rf __output
