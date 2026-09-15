# Baut alle C#-Projekte unter bausteine/, um Kompilierfehler fruehzeitig zu
# finden (z.B. durch neue Avalonia-Versionen). Bricht beim ersten Fehler ab.
#
# Manche Aufgaben-Startcode-Projekte compilieren absichtlich nicht (Main
# oder Implementierung fehlt noch, Studierende ergaenzen das). Projekten,
# denen nur die Main-Methode fehlt, wird dafuer eine temporaere Main
# spendiert, damit Nachbarprojekte in derselben Solution trotzdem geprueft
# werden. Projekten, denen mehr fehlt, werden ganz uebersprungen.
#
# Aufruf im Projekt-Wurzelverzeichnis: julia skripte/build-dotnet.jl

const DUMMY_MAIN_DIRS = [
	"bausteine/03-elementare-datentypen/aufgaben/projekt/01-variablen",
	"bausteine/04-objekte/aufgaben/projekt/02-referenzvariablen",
	"bausteine/04-objekte/aufgaben/projekt/03-hallenrechner-2",
	"bausteine/05-klassen/aufgaben/projekt/01-complex",
	"bausteine/05-klassen/aufgaben/projekt/02-fraction",
	"bausteine/05-klassen/aufgaben/projekt/03-section",
	"bausteine/06-kontrollstrukturen/aufgaben/projekt/01-fraction",
	"bausteine/06-kontrollstrukturen/aufgaben/projekt/02-ford-circles",
	"bausteine/09-vererbung/aufgaben/projekt/02-beam",
]

const EXCLUDE = [
	"bausteine/07-einfeldtraeger-mit-tests/aufgaben/projekt/beam/beam.csproj",
	"bausteine/07-einfeldtraeger-mit-tests/aufgaben/projekt/beam-test/beam-test.csproj",
	"bausteine/08-datenstrukturen/aufgaben/projekt/01-vector-tests/vector-tests.csproj",
	"bausteine/08-datenstrukturen/aufgaben/projekt/02-trigonometric-polynomial-tests/trigonometric-polynomial-tests.csproj",
	"bausteine/09-vererbung/aufgaben/projekt/02-beam-test/beam-test.csproj",
]

function csproj_files()
	files = String[]
	for (dir, _, names) in walkdir("bausteine")
		for name in names
			endswith(name, ".csproj") && push!(files, joinpath(dir, name))
		end
	end
	sort!(files)
end

function build_all()
	dummy_files = [joinpath(d, "__ci_dummy_main.cs") for d in DUMMY_MAIN_DIRS]
	for f in dummy_files
		write(f, "Console.WriteLine(\"dummy\");\n")
	end
	try
		for proj in csproj_files()
			proj in EXCLUDE && continue
			println("::group::", proj)
			flush(stdout)
			ok = try
				run(`dotnet build $proj --nologo`)
				true
			catch
				false
			finally
				println("::endgroup::")
				flush(stdout)
			end
			ok || return false
		end
		return true
	finally
		rm.(dummy_files, force=true)
	end
end

exit(build_all() ? 0 : 1)
