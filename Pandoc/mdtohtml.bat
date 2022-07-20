@ECHO off
REM Use Pandoc to convert (GitHub flavored) Markdown to HTML
REM https://pandoc.org/installing.html#windows

REM Convert Markdown to HTML
pandoc --standalone --self-contained -f gfm "What's new.md" -o "What's new.html" --css=pandoc-style.css -H pandoc-header.html

REM Convert Markdown to RTF
pandoc --standalone "What's new.md" -o "What's new.rtf"