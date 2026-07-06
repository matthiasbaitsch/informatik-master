# Mehrfach vorhandene Dateien konsistent halten: findet inhaltsgleiche
# (git-verwaltete) Dateien und schreibt die Gruppen nach skripte/duplikate.txt.
#
# Der Pre-Commit-Hook (githooks/pre-commit, aktiviert per
# git config core.hooksPath githooks) führt das Skript aus und bricht ab,
# wenn sich duplikate.txt dabei ändert. Dann: Änderung in alle Kopien
# übernehmen – oder duplikate.txt mit committen, falls die Abweichung
# gewollt ist.

using SHA

cd(dirname(@__DIR__))

const LIST_FILE = "skripte/duplikate.txt"
const EXCLUDED = [r"\.lscache$", r"\.editorconfig$", r"\.code-workspace$", r"/\.vscode/"]

files = readlines(`git ls-files bausteine studienarbeit`)
filter!(file -> isfile(file) && !any(pattern -> occursin(pattern, file), EXCLUDED), files)

groups = Dict{String, Vector{String}}()
for file in files
	push!(get!(groups, bytes2hex(sha256(read(file))), String[]), file)
end
duplicates = sort([sort(group) for group in values(groups) if length(group) > 1])

open(LIST_FILE, "w") do io
	for group in duplicates
		foreach(file -> println(io, file), group)
		println(io)
	end
end
println("$(sum(length, duplicates, init = 0)) Dateien in $(length(duplicates)) Gruppen -> $LIST_FILE")
