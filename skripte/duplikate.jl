using SHA

# Constants
const ROOT = readchomp(`git rev-parse --show-toplevel`)
const LIST_FILE = joinpath(ROOT, "skripte/duplikate.txt")

# Dict sha -> file
filedict = Dict{Vector{UInt8}, Vector{String}}()
for file in eachline(`git ls-files --full-name`)
	path = joinpath(ROOT, file)
	if isfile(path)
		push!(get!(filedict, sha256(read(path)), String[]), file)
	end
end

# Collect groups of identical files
groups = values(filedict) |> collect |> filter(a -> length(a) > 1) .|> sort! |> sort!

# Write groups to file
write(LIST_FILE, join(join.(groups, "\n"), "\n\n"))
