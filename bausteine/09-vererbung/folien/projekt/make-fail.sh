#!/bin/bash
SRC="sysdraw-step-03/Structure.cs"
DST="sysdraw-step-03/fail/Structure.cs"
cp "$SRC" "$DST"
sed -i '' '23s/$/    💥🤯👹🪲💣/' "$DST"