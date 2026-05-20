ca_include_code <- function(code, ll="true") {
  b <- "```"
  glue::glue(
'
{b}{{.csharp code-line-numbers="{ll}" style="font-size: 0.9em;"}}
{code}
{b}
'
  )
}

ca_include_raw <- function(code) {
  b <- "```"
  glue::glue(
'
{b}{{.raw style="font-size: 0.9em;"}}
{code}
{b}
'
  )
}

ca_make_animation <- function(title, lc, rc, lines) {
  for(i in seq_along(lines)) {
    cat(
        glue::glue(
'
## {title}

::: {{.columns}}
::: {{.column width="57%"}}
{lc(i, lines[i])}
:::
::: {{.column width="2.5%"}}
:::
::: {{.column width="37.5%"}}
{rc(i, lines[i])}
:::
:::

'
        )
    )
}
}
