using Mmap
using YAML
using Random
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

function copy_qmd(header::String, bb::BuildingBlock, from_folder::String, to_file::String)
    text = header
    text *= "\n"
    for f = filter(f -> endswith(f, ".qmd"), readdir(from_folder, join=true))
        text *= read(f, String)
        text *= "\n\n"
    end
    text = substitute_text(text, make_dict(bb))
    write(to_file, text)
end

function copy_files(from_folder::String, to_folder::String, allow_duplicates::Bool=false)
    if isdir(from_folder)
        !isdir(to_folder) && mkpath(to_folder)
        for f = readdir(from_folder)
            source_path = joinpath(from_folder, f)
            target_path = joinpath(to_folder, f)
            if isfile(source_path) && f != ".DS_Store"
                if !isfile(target_path)
                    cp(source_path, target_path)
                else
                    if allow_duplicates
                        if mmap(open(source_path)) != mmap(open(target_path))
                            error("Files not identical: ", source_path, " != ", target_path)
                        end
                    else
                        error("Target file exists: ", target_path)
                    end
                end
            end
        end
    end
end

function copy_images_folder(from_folder::String, to_folder::String)
    copy_files(joinpath(from_folder, "bilder"), joinpath(to_folder, "bilder"))
end

function try_zip_folder(folder, folder_in_zipfile, zipfile)
    !isdir(folder) && return
    ZipWriter(zipfile) do w
        for (root, _, files) in walkdir(folder)
            for file in files
                if !occursin(r"/obj\b|/bin\b", root) && file != ".DS_Store"
                    file_path = joinpath(root, file)
                    zip_path = joinpath(folder_in_zipfile, relpath(file_path, folder))
                    zip_newfile(w, zip_path; compress=true)
                    write(w, read(file_path))
                end
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
    copy_qmd(h, bb, path_input, joinpath(path_output, slug(bb) * ".qmd"))
    copy_images_folder(path_input, path_output)
end

function make_assignments(bb::BuildingBlock, path_input, path_output)

    # Header for qmd file
    header = """
    ---
    number-offset: $(bb.number - 1)
    format:
        typst:
            include-in-header:
                text: |
                    #counter(heading).update($(bb.number - 1))
    ---
    # $(bb.title) (Aufgaben)
    """

    # Copy
    copy_qmd(header, bb, path_input, joinpath(path_output, slug(bb) * "-aufgaben.qmd"))
    copy_images_folder(path_input, path_output)

    # Zip project folder
    try_zip_folder(
        joinpath(path_input, "projekt"),
        slug(bb),
        joinpath(path_output, slug(bb) * ".zip")
    )
    try_zip_folder(
        joinpath(path_input, "projekt-loesung"),
        slug(bb) * "-loesung",
        joinpath(path_output, slug(bb) * "-loesung-$(join(rand('a':'z', 5))).zip")
    )
end


# -------------------------------------------------------------------------------------------------
# Main
# -------------------------------------------------------------------------------------------------

Random.seed!(87362)
bausteine_folder = realpath(joinpath(@__DIR__, "../../bausteine"))
lernpfad_folder = realpath(joinpath(@__DIR__, ".."))

components = [
    (make_slides, "folien"),
    (make_assignments, "aufgaben")
]

paths = readdir(bausteine_folder, join=true) |>
        filter(d -> isdir(d) && !occursin(r"\.DS_Store|00-templates", d))

for path = paths
    bb = BuildingBlock(path)
    for (make_function, folder) = components
        wiped = false
        path_input = joinpath(path, folder)
        if isdir(path_input)
            output_folder = joinpath(lernpfad_folder, folder, "c")
            if !wiped
                rm(output_folder, force=true, recursive=true)
                mkpath(output_folder)
                wiped = true
            end
            copy_files(bausteine_folder, output_folder, true)
            make_function(bb, path_input, output_folder)
        end
    end
end
