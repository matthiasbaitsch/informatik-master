## Programmierung

Nuget Cache leeren

```raw
dotnet nuget locals all -c
```

## Quarto / Reveal.js

- Text automatisch so skalieren, dass er die Folie ausfüllt:

    ```markdown
    ::: {.r-fit-text}
    Text hier
    :::
    ```

- Code mit Zeilennummern

    ```{.csharp code-line-numbers="true"}
    ```

- Link in neuem Fenster

    ```
    [link](url){target="_blank"}
    ```
    
