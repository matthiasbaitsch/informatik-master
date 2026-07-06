prepare-render:
	cd skripte && julia -t1 --project lernpfad-zusammenstellen.jl || exit 1
	cd skripte && julia -t1 --project studienarbeit-zusammenstellen.jl || exit 1

render-assignments: prepare-render
	quarto render lernpfad/aufgaben -t html

render-slides: prepare-render
	quarto render lernpfad/folien -t revealjs

render-study-assignments: prepare-render
	quarto render lernpfad/studienarbeit

render: render-slides render-assignments

copy-templates:
	for f in bausteine/*/*/projekt*; do \
		package=`echo $$f | cut -d'/' -f2 | sed 's/^[0-9]*-//'`; \
		if [[ "$$f" == *-musterloesung ]]; then \
			package=$$package-musterloesung; \
		fi; \
		if [[ "$$f" == *-schritte ]]; then \
			package=$$package-schritte; \
		fi; \
		cp bausteine/00-templates/.editorconfig $$f; \
		cp -r bausteine/00-templates/.vscode $$f; \
		cp bausteine/00-templates/projekt.code-workspace $$f/$$package.code-workspace; \
	done

clean:
	rm -rf lernpfad/*/c
	rm -rf __output
