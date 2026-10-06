PDF_JOBS ?= 4
DECKTAPE_ARGS ?=

prepare-render:
	cd skripte && julia -t1 --project lernpfad-zusammenstellen.jl || exit 1
	cd skripte && julia -t1 --project studienarbeit-zusammenstellen.jl || exit 1

render-assignments: prepare-render
	quarto render lernpfad/aufgaben -t html

render-slides: prepare-render
	quarto render lernpfad/folien -t revealjs

render-slides-all: prepare-render
	quarto render lernpfad/folien-alle -t html

render-slides-pdf:
	find __output/lernpfad/folien/c -maxdepth 1 -name '*.html' -print0 | \
		xargs -0 -P $(PDF_JOBS) -I {} sh -c 'decktape reveal $(DECKTAPE_ARGS) -s 1050x700 -p 200 "$$1" "$${1%.html}.pdf"' _ {}

save-slides-pdf:
	mkdir -p __vergleich
	cp __output/lernpfad/folien/c/*.pdf __vergleich/

diff-slides-pdf:
	mkdir -p __vergleich/diff
	for f in __vergleich/*.pdf; do \
		n=`basename "$$f"`; \
		if diff-pdf -s -m --output-diff="__vergleich/diff/$$n" "$$f" "__output/lernpfad/folien/c/$$n"; then \
			echo "gleich:      $$n"; \
		else \
			echo "verschieden: $$n"; \
		fi; \
	done

render-study-assignments: prepare-render
	quarto render lernpfad/studienarbeit

render-additional-materials:
	quarto render weitere-unterlagen -t html

render: render-study-assignments render-assignments render-slides render-slides-all render-additional-materials

publish: render render-slides-pdf

copy-templates:
	for f in bausteine/*/*/projekt*; do \
		package=`echo $$f | cut -d'/' -f2 | sed 's/^[0-9]*-//'`; \
		if [[ "$$f" == *-musterloesung ]]; then \
			package=$$package-musterloesung; \
		fi; \
		if [[ "$$f" == *-schritte ]]; then \
			package=$$package-schritte; \
		fi; \
		if [[ "$$f" == *-playground ]]; then \
			package=$$package-playground; \
		fi; \
		cp bausteine/00-templates/.editorconfig $$f; \
		cp -r bausteine/00-templates/.vscode $$f; \
		others=`ls $$f/*.code-workspace 2>/dev/null | grep -v "/$$package.code-workspace$$"`; \
		if [[ -z "$$others" ]]; then \
			cp bausteine/00-templates/projekt.code-workspace $$f/$$package.code-workspace; \
		fi; \
	done

build-dotnet:
	julia skripte/build-dotnet.jl

clean:
	rm -rf lernpfad/*/c
	rm -rf __output
