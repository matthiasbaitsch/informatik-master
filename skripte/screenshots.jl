# Erzeugt die Screenshots der Beispielprojekte für die Folien.
#
# Liest die .slnx-Datei im aktuellen Arbeitsverzeichnis und startet für jedes
# darin gelistete Projekt die App, fotografiert das Fenster und speichert es
# als NN-name.png im Bilderordner (../bilder, falls vorhanden, sonst das
# aktuelle Verzeichnis). 01-clickme wird übersprungen (Spezialfall mit
# Klick-Zustand).
#
# Voraussetzungen:
#   brew install smokris/getwindowid/getwindowid
#   Bildschirmaufnahme-Berechtigung für das Terminal (macOS fragt beim ersten Mal)
#
# Aufruf im Verzeichnis mit der .slnx-Datei, z.B.:
#   cd bausteine/10-gui/folien/projekt
#   julia ../../../../skripte/screenshots.jl          # alle Projekte der Solution
#   julia ../../../../skripte/screenshots.jl 06 99    # nur Projektordner mit diesen Präfixen
#
# Zum Debuggen, falls ein Fenster nicht gefunden wird:
#   GetWindowID <app-name> --list

if isnothing(Sys.which("GetWindowID"))
	error("GetWindowID fehlt – installieren mit: brew install smokris/getwindowid/getwindowid")
end

# Fenster-ID der App ermitteln, nothing wenn (noch) nicht vorhanden
function windowid(app, title)
	try
		id = readchomp(`GetWindowID $app $title`)
		return isempty(id) ? nothing : id
	catch
		return nothing
	end
end

slnxfiles = filter(endswith(".slnx"), readdir())
length(slnxfiles) == 1 ||
	error("Genau eine .slnx-Datei im aktuellen Verzeichnis erwartet – im Projektordner aufrufen")

csprojs = [m[1] for m in eachmatch(r"Path=\"([^\"]+\.csproj)\"", read(only(slnxfiles), String))]
outdir = isdir("../bilder") ? "../bilder" : "."

for csproj in csprojs
	dir = dirname(csproj)
	name = basename(dir)
	app = first(splitext(basename(csproj)))

	startswith(name, "01-") && continue
	isempty(ARGS) || any(prefix -> startswith(name, prefix), ARGS) || continue

	m = match(r"Title=\"([^\"]*)\"", read(joinpath(dir, "MainWindow.axaml"), String))
	title = isnothing(m) ? "" : m[1]
	out = joinpath(outdir, "$name.png")

	println("→ $name (App: $app, Fenstertitel: \"$title\")")

	run(`dotnet build $dir --nologo -v q`)
	process = run(`dotnet run --project $dir --no-build`, wait=false)

	# Warten, bis das Fenster erschienen ist (max. 30 s)
	id = nothing
	for _ in 1:60
		id = windowid(app, title)
		isnothing(id) || break
		sleep(0.5)
	end

	if isnothing(id)
		println(stderr, "   Fenster nicht gefunden – überspringe")
	else
		sleep(1)   # fertig rendern lassen
		run(`screencapture -x -o -l $id $out`)
		println("   gespeichert: $out")
	end

	success(`pkill -x $app`)   # App beenden
	wait(process)
end
