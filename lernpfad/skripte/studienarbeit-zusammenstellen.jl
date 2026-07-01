using YAML

# -------------------------------------------------------------------------------------------------
# Helpers
# -------------------------------------------------------------------------------------------------

function extract_content(file)
	!isfile(file) && error("No such file: $file")
	text = read(file, String)
	m = match(r"^---\n(.*?)\n---\n(.*)"s, text)
	isnothing(m) && error("No YAML front matter found in: $file")

	meta       = YAML.load(m[1])
	titel      = get(meta, "titel", "")
	betreuende = get(meta, "betreuende", "")
	literatur  = get(meta, "literatur", String[])
	inhalt     = strip(m[2])

	return (titel = titel, betreuende = betreuende, literatur = literatur, inhalt = inhalt)
end

function fill_template(abgabetermin, content, template_text)
	lit_text        = !isnothing(content.literatur) ? join("- " .* content.literatur, "\n") : ""
	betreuende_text = !isnothing(content.betreuende) ? join("- " .* content.betreuende, "\n") : ""

	template_text = replace(template_text,
		"<<titel>>"        => content.titel,
		"<<inhalt>>"       => content.inhalt,
		"<<literatur>>"    => lit_text,
		"<<betreuende>>"   => betreuende_text,
		"<<abgabetermin>>" => abgabetermin,
	)
	return template_text
end

function process_yaml_for_year(file, pool_folder, output_folder_base, template_text)
	!isfile(file) && error("No such file: $file")

	# basic stuff
	data            = YAML.load_file(file)
	assignments     = get(data, "aufgaben", String[])
	year            = parse(Int, splitext(basename(file))[1])
	submission_date = get(data, "abgabetermin", "")
	output_folder   = joinpath(output_folder_base, string(year))

	# Make folder and copy images
	mkpath(output_folder)
	cp(joinpath(pool_folder, "bilder"), joinpath(output_folder, "bilder"))

	# HTML
	open(joinpath(output_folder, "index.html"), "w") do html_io

		# Start html
		println(html_io, "<ol>")

		# Process assignments
		for (i, a) ∈ enumerate(assignments)

			# Input and output destinations
			in_file         = joinpath(pool_folder, a * ".qmd")
			content         = extract_content(in_file)
			assignment_text = fill_template(submission_date, content, template_text)
			out_base        = "a" * lpad(string(i), 2, "0") * "-" * a
			out_file        = out_base * ".qmd"
			out_url         = "https://matthiasbaitsch.github.io/informatik-master/lernpfad/studienarbeit/c/$year/$out_base.html"

			# Write
			write(joinpath(output_folder, out_file), assignment_text)
			println(html_io, "<li> <a href=\"$out_url\" target=\"_blank\">$(content.titel)</a><br/>($(content.betreuende[1]))</li>")
		end

		# Finish html
		println(html_io, "</ol>")
	end
end

# -------------------------------------------------------------------------------------------------
# Main
# -------------------------------------------------------------------------------------------------

template_file        = realpath(joinpath(@__DIR__, "../../studienarbeit/template.qmd"))
studienarbeit_folder = realpath(joinpath(@__DIR__, "../../studienarbeit"))
lernpfad_folder      = realpath(joinpath(@__DIR__, ".."))
pool_folder          = joinpath(studienarbeit_folder, "aufgabenpool")
output_folder        = joinpath(lernpfad_folder, "studienarbeit", "c")
template_text        = read(template_file, String)

# Clean
isdir(output_folder) && rm(output_folder, recursive = true)

# Process files
for f ∈ filter(f -> endswith(f, ".yaml"), readdir(joinpath(lernpfad_folder, "studienarbeit"), join = true))
	process_yaml_for_year(f, pool_folder, output_folder, template_text)
end

# Copy
for f ∈ ["_metadata.yaml"]
	cp(joinpath(studienarbeit_folder, f), joinpath(output_folder, f))
end


