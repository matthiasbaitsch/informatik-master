using YAML
using ZipArchives


# -------------------------------------------------------------------------------------------------
# Building block
# -------------------------------------------------------------------------------------------------

struct BuildingBlock
    path::String
    number::Int
    name::String
    title::String
    content::Vector{String}
    duration::Number
end

function BuildingBlock(path::String)
    bn = basename(path)
    about = YAML.load_file(joinpath(path, "about.yaml"))
    return BuildingBlock(
        path,
        parse(Int, bn[1:2]), bn[4:end],
        about["titel"], about["inhalt"], about["dauer"]
    )
end

function slug(bb::BuildingBlock)
    return lpad(bb.number, 2, '0') * "-" * replace(lowercase(bb.title), " " => "-")
end

function make_dict(bb::BuildingBlock)
    return Dict(
        "title" => bb.title,
        "slug" => slug(bb),
        "slug-nn" => slug(bb)[4:end],
    )
end

# -------------------------------------------------------------------------------------------------
# Helpers
# -------------------------------------------------------------------------------------------------

function substitute_text(text::String, dict::Dict)
    for (key, value) in dict
        text = replace(text, "\${$(key)}" => string(value))
    end
    return text
end

function do_copy_qmd(header::String, bb::BuildingBlock, from_folder::String, to_file::String)
    text = header
    text *= "\n"
    for f = filter(f -> endswith(f, ".qmd"), readdir(from_folder, join=true))
        text *= read(f, String)
        text *= "\n\n"
    end
    text = substitute_text(text, make_dict(bb))
    write(to_file, text)
end


function zip_folder(folder_path, output_zip_path)
    ZipWriter(output_zip_path) do w
        for (root, _, files) in walkdir(folder_path)
            for file in files
                file_path = joinpath(root, file)
                zip_path = relpath(file_path, folder_path)
                zip_newfile(w, zip_path; compress=true)
                write(w, read(file_path))
            end
        end
    end
end

# -------------------------------------------------------------------------------------------------
# Make stuff
# -------------------------------------------------------------------------------------------------

function make_slides(bb::BuildingBlock, path_input, path_output)
    h = """
    ---
    title: \${title}
    subtitle: Modul Informatik im Master Bauingenieurwesen
    ---
    """
    do_copy_qmd(h, bb, path_input, joinpath(path_output, slug(bb) * ".qmd"))
end

function make_assignments(bb::BuildingBlock, path_input, path_output)
    h = """
    ---
    title: Aufgaben zum Paket \"\${title}\"
    ---
    """
    do_copy_qmd(h, bb, path_input, joinpath(path_output, slug(bb) * "-aufgaben.qmd"))

    p = joinpath(path_input, "projekt")
    if isdir(p)
        zip_folder(p, joinpath(path_output, slug(bb) * ".zip"))
    end
end

# -------------------------------------------------------------------------------------------------
# Main
# -------------------------------------------------------------------------------------------------

bausteine_folder = realpath(joinpath(@__DIR__, "../../bausteine"))
lernpfad_folder = realpath(joinpath(@__DIR__, ".."))

components = [
    (make_slides, "folien"),
    (make_assignments, "aufgaben")
]

# paths = collect(readdir(bausteine_folder, join=true))
paths = filter(
    d -> !occursin(r"\.DS_Store|00-templates", d),
    readdir(bausteine_folder, join=true)
)

for path = paths
    bb = BuildingBlock(path)
    for (func, folder) = components
        path_input = joinpath(path, folder)
        if isdir(path_input)
            path_output = joinpath(lernpfad_folder, folder, "c")
            !isdir(path_output) && mkpath(path_output)
            func(bb, path_input, path_output)
        end
    end
end
